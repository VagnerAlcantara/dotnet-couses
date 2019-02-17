using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Locadora.Data
{
    public class Connection : IDisposable
    {
        private static readonly string _ConnectioString = ConfigurationManager.ConnectionStrings["connLocadora"].ConnectionString;

        private SqlConnection _SqlConnection;

        public Connection()
        {
            this.Open(_ConnectioString);
        }

        internal void Open(string connection)
        {
            try
            {
                if (_SqlConnection == null)
                    _SqlConnection = new SqlConnection(connection);

                _SqlConnection.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void ExecuteProcedure(string command, List<SqlParameter> parameters)
        {
            try
            {
                using (var cnn = new Connection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(command, cnn._SqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void ExecuteProcedure(string command, SqlParameter parameter)
        {
            try
            {
                using (var cnn = new Connection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(command, cnn._SqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(parameter);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal DataTable ExecuteReader(string command, SqlParameter parameter)
        {
            try
            {
                using (var cnn = new Connection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(command, cnn._SqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(parameter);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(sqlDataReader);

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal DataTable ExecuteReader(string command)
        {
            try
            {
                using (var cnn = new Connection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(command, cnn._SqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Load(sqlDataReader);

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            this._SqlConnection.Dispose();
        }

    }
}

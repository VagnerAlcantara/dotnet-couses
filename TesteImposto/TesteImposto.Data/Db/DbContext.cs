using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Locadora.Data
{
    public class DbContext : IDisposable
    {
        private static readonly string _connectioString = ConfigurationManager.ConnectionStrings["connTeste"].ConnectionString;

        internal SqlConnection SqlConnection;
        internal SqlTransaction SqlTransaction;

        public DbContext()
        {
            if (SqlConnection == null)
                SqlConnection = new SqlConnection(_connectioString);

            if (SqlConnection.State == ConnectionState.Closed)
                SqlConnection.Open();

            SqlTransaction = SqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            if (SqlConnection.State == ConnectionState.Open && SqlTransaction != null)
                SqlTransaction.Commit();
        }

        public void Rollback()
        {
            if (SqlConnection.State == ConnectionState.Open && SqlTransaction != null)
                SqlTransaction.Rollback();
        }

        public void Dispose()
        {
            SqlConnection.Dispose();
            SqlTransaction.Dispose();
        }

    }
}

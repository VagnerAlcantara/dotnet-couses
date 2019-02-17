using Locadora.Domain.Entities;
using Locadora.Domain.Interface.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Locadora.Data
{
    public class FilmeRepository : IFilmeRepository
    {
        private Connection _connection;

        public void Adicionar(Filme entity)
        {
            try
            {
                using (_connection = new Connection())
                {

                    List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@id",  Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@titulo", Value = entity.Titulo, SqlDbType = SqlDbType.VarChar, Size = 150 },
                        new SqlParameter() { ParameterName = "@ano",Value = entity.Ano, SqlDbType = SqlDbType.Int}
                    };

                    _connection.ExecuteProcedure("PROC_FILME_INSERT", parameterList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Filme entity)
        {
            using (_connection = new Connection())
            {

                List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@id",  Value = entity.Id, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@titulo", Value = entity.Titulo, SqlDbType = SqlDbType.VarChar, Size = 150 },
                        new SqlParameter() { ParameterName = "@ano",Value = entity.Ano, SqlDbType = SqlDbType.Int}
                    };

                _connection.ExecuteProcedure("PROC_FILME_UPDATE", parameterList);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                using (_connection = new Connection())
                {
                    _connection.ExecuteProcedure("PROC_FILME_DELETE", new SqlParameter() { ParameterName = "@id", Value = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Filme Obter(int id)
        {
            try
            {
                using (_connection = new Connection())
                {
                    var dataTable = _connection.ExecuteReader("PROC_FILME_SELECT_POR_ID", new SqlParameter() { ParameterName = "@id", Value = id });

                    var result = dataTable.AsEnumerable().Select(row => new Filme(
                       row.Field<int>("ID"),
                       row.Field<string>("TITULO"),
                       row.Field<int>("ANO")
                       ));

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Filme> Obter(string titulo)
        {
            try
            {
                using (_connection = new Connection())
                {
                    var dataTable = _connection.ExecuteReader("PROC_FILME_SELECT_POR_TITULO", new SqlParameter() { ParameterName = "@titulo", Value = titulo });

                    var result = dataTable.AsEnumerable().Select(row => new Filme(
                       row.Field<int>("ID"),
                       row.Field<string>("TITULO"),
                       row.Field<int>("ANO")
                       ));

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Filme> Obter()
        {
            try
            {
                using (_connection = new Connection())
                {
                    var dataTable = _connection.ExecuteReader("SELECT TOP 10 * FROM FILME");

                    var result = dataTable.AsEnumerable().Select(row => new Filme(
                       row.Field<int>("ID"),
                       row.Field<string>("TITULO"),
                       row.Field<int>("ANO")
                       ));

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }


    }
}

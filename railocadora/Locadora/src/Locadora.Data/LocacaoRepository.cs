using Locadora.Domain.Entities;
using Locadora.Domain.Interface.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Locadora.Data
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private Connection _connection;

        public void Adicionar(Locacao entity)
        {
            try
            {
                using (_connection = new Connection())
                {

                    List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@id",  Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@idFilme",  Value = entity.IdFilme, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@idCliente",  Value = entity.IdCliente, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@dataRetirada",  Value = entity.DataRetirada, SqlDbType = SqlDbType.DateTime },
                        new SqlParameter() { ParameterName = "@dataEntrega",  Value = entity.DataEntrega, SqlDbType = SqlDbType.DateTime }
                    };

                    _connection.ExecuteProcedure("PROC_LOCACAO_INSERT", parameterList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Locacao entity)
        {
            using (_connection = new Connection())
            {

                List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@id",  Value = entity.Id, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@idFilme",  Value = entity.IdFilme, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@idCliente",  Value = entity.IdCliente, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@dataRetirada",  Value = entity.DataRetirada, SqlDbType = SqlDbType.DateTime },
                        new SqlParameter() { ParameterName = "@dataEntrega",  Value = entity.DataEntrega, SqlDbType = SqlDbType.DateTime }
                    };

                _connection.ExecuteProcedure("PROC_LOCACAO_UPDATE", parameterList);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                using (_connection = new Connection())
                {
                    _connection.ExecuteProcedure("PROC_LOCACAO_DELETE", new SqlParameter() { ParameterName = "@id", Value = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Locacao Obter(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public List<Locacao> ObterPorCliente(int idCliente)
        {
            try
            {
                using (_connection = new Connection())
                {
                    var dataTable = _connection.ExecuteReader("PROC_LOCACAO_SELECT_POR_ID_CLIENTE", new SqlParameter() { ParameterName = "@id", Value = idCliente });

                    var result = dataTable.AsEnumerable().Select(row => new Locacao(
                       row.Field<int>("ID"),
                       row.Field<int>("IDFILME"),
                       row.Field<int>("IDCLIENTE"),
                       row.Field<DateTime>("DATARETIRADA"),
                       row.Field<DateTime>("DataEntrega")
                       ));

                    return result.ToList<Locacao>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

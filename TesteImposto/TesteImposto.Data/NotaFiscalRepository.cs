using Locadora.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Repositories;

namespace TesteImposto.Data
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private DbContext _dbContext;

        public void GerarNotaFiscal(NotaFiscal entity)
        {
            using (_dbContext = new DbContext())
            {
                List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                    new SqlParameter() { ParameterName = "@pId", Value = entity.Id, Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                    new SqlParameter() { ParameterName = "@pNumeroNotaFiscal", Value = entity.NumeroNotaFiscal, SqlDbType = SqlDbType.Int },
                    new SqlParameter() { ParameterName = "@pSerie", Value = entity.Serie, SqlDbType = SqlDbType.Int },
                    new SqlParameter() { ParameterName = "@pNomeCliente", Value = entity.NomeCliente, SqlDbType = SqlDbType.VarChar, Size = 50 },
                    new SqlParameter() { ParameterName = "@pEstadoDestino", Value = entity.EstadoDestino, SqlDbType = SqlDbType.VarChar, Size = 50 },
                    new SqlParameter() { ParameterName = "@pEstadoOrigem", Value = entity.EstadoOrigem, SqlDbType = SqlDbType.VarChar, Size = 50 }
                };

                using (SqlCommand sqlCommand = new SqlCommand("P_NOTA_FISCAL", _dbContext.SqlConnection, _dbContext.SqlTransaction))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(parameterList.ToArray());
                        var result = sqlCommand.ExecuteReader();

                        if (result != null)
                            entity.Id = Convert.ToInt32(result);

                        NotaFiscalItemRepository notaFiscalItemRepository = new NotaFiscalItemRepository();
                        notaFiscalItemRepository.Add(entity.ItensDaNotaFiscal, entity.Id);
                        _dbContext.Commit();
                    }
                    catch (Exception ex)
                    {
                        _dbContext.Dispose();
                        _dbContext.Rollback();
                    }
                    finally
                    {
                        _dbContext.Dispose();
                    }
                }
            }
        }
    }
}
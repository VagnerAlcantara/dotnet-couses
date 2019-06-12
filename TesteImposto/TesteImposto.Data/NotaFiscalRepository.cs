using Locadora.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Repositories;
using TesteImposto.Shared;

namespace TesteImposto.Data
{
    public class NotaFiscalRepository : Notification, INotaFiscalRepository
    {
        private DbContext _dbContext;

        /// <summary>
        /// Grava a nota fiscal
        /// </summary>
        /// <param name="notaFiscal">Dados da Nota fiscal</param>
        public void GravarNotaFiscal(NotaFiscal notaFiscal)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                    new SqlParameter() { ParameterName = "@pId", Value = notaFiscal.Id, Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                    new SqlParameter() { ParameterName = "@pNumeroNotaFiscal", Value = notaFiscal.NumeroNotaFiscal, SqlDbType = SqlDbType.Int },
                    new SqlParameter() { ParameterName = "@pSerie", Value = notaFiscal.Serie, SqlDbType = SqlDbType.Int },
                    new SqlParameter() { ParameterName = "@pNomeCliente", Value = notaFiscal.NomeCliente, SqlDbType = SqlDbType.VarChar, Size = 50 },
                    new SqlParameter() { ParameterName = "@pEstadoDestino", Value = notaFiscal.EstadoDestino, SqlDbType = SqlDbType.VarChar, Size = 50 },
                    new SqlParameter() { ParameterName = "@pEstadoOrigem", Value = notaFiscal.EstadoOrigem, SqlDbType = SqlDbType.VarChar, Size = 50 }
                };

            using (_dbContext = new DbContext())
            {
                using (SqlCommand sqlCommand = new SqlCommand("P_NOTA_FISCAL", _dbContext.SqlConnection, _dbContext.SqlTransaction))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(parameterList.ToArray());
                        var result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            notaFiscal.Id = Convert.ToInt32(result);
                        else
                        {
                            AddError("Erro ao gravar Nota Fiscal.");
                        }

                        NotaFiscalItemRepository notaFiscalItemRepository = new NotaFiscalItemRepository();
                        notaFiscalItemRepository.GravarItemNotaFiscal(notaFiscal.ItensDaNotaFiscal, notaFiscal.Id);

                        if (notaFiscalItemRepository.IsValid)
                            _dbContext.Commit();
                        else
                        {
                            AddError(notaFiscalItemRepository.Errors);
                            _dbContext.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        AddError("Erro ao gravar Nota Fiscal. details: " + ex.Message);
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
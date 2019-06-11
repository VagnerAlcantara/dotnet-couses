using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Repositories;

namespace TesteImposto.Data
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private static readonly string _connectioString = ConfigurationManager.ConnectionStrings["connTeste"].ConnectionString;

        public void GerarNotaFiscal(NotaFiscal entity)
        {
            if (!entity.IsValid)
                return;

            SqlTransaction trans = null;

            try
            {
                using (var conn = new SqlConnection(_connectioString))
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (SqlCommand sqlCommand = new SqlCommand("P_NOTA_FISCAL", conn, trans))
                    {

                        List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@pId",  Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@pNumeroNotaFiscal", Value = entity.NumeroNotaFiscal, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@pSerie",Value = entity.Serie, SqlDbType = SqlDbType.Int},
                        new SqlParameter() { ParameterName = "@pNomeCliente", Value = entity.NomeCliente, SqlDbType =  SqlDbType.VarChar, Size = 50},
                        new SqlParameter() { ParameterName = "@pEstadoDestino", Value = entity.EstadoDestino, SqlDbType = SqlDbType.VarChar, Size = 50},
                        new SqlParameter() { ParameterName = "@pEstadoOrigem", Value = entity.EstadoOrigem, SqlDbType = SqlDbType.VarChar, Size = 50}
                    };

                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddRange(parameterList.ToArray());

                        try
                        {
                            entity.SetId(sqlCommand.ExecuteNonQuery());
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                        }

                        NotaFiscalItemRepository notaFiscalItemRepository = new NotaFiscalItemRepository();

                        try
                        {
                            notaFiscalItemRepository.Add(entity.ItensDaNotaFiscal, entity.Id);
                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
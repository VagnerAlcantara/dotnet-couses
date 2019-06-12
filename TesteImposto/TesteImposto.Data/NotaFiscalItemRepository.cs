using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Repositories;
using TesteImposto.Shared;

namespace TesteImposto.Data
{
    internal class NotaFiscalItemRepository : Notification, INotaFiscalItemRepository
    {
        /// <summary>
        /// Grava um item da nota fiscal
        /// </summary>
        /// <param name="notaFiscalItem">Item da nota fiscal</param>
        private void GravarItemNotaFiscal(NotaFiscalItem notaFiscalItem)
        {
            using (var conn = new SqlConnection(DbContext.SqlConn))
            {
                conn.Open();

                List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@pId",  Value = notaFiscalItem.Id, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@pIdNotaFiscal", Value = notaFiscalItem.IdNotaFiscal, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@pCfop",Value = notaFiscalItem.Cfop, SqlDbType = SqlDbType.VarChar, Size = 5},
                        new SqlParameter() { ParameterName = "@pTipoIcms", Value = notaFiscalItem.TipoIcms, SqlDbType =  SqlDbType.VarChar, Size = 20},
                        new SqlParameter() { ParameterName = "@pBaseIcms", Value = notaFiscalItem.BaseIcms, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pAliquotaIcms", Value = notaFiscalItem.AliquotaIcms, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pValorIcms", Value = notaFiscalItem.ValorIcms, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pNomeProduto", Value = notaFiscalItem.NomeProduto, SqlDbType = SqlDbType.VarChar, Size = 50},
                        new SqlParameter() { ParameterName = "@pCodigoProduto", Value = notaFiscalItem.CodigoProduto, SqlDbType = SqlDbType.VarChar, Size = 50},

                        new SqlParameter() { ParameterName = "@pBaseCalculoIpi", Value = notaFiscalItem.BaseCalculoIpi, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pAliquotaIpi", Value = notaFiscalItem.AliquotaIpi, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pValorIpi", Value = notaFiscalItem.ValorIpi, SqlDbType = SqlDbType.Decimal},

                        new SqlParameter() { ParameterName = "@pPercentualDesconto", Value = notaFiscalItem.PercentualDesconto, SqlDbType = SqlDbType.Decimal},


                    };
                using (SqlCommand sqlCommand = new SqlCommand("P_NOTA_FISCAL_ITEM", conn))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(parameterList.ToArray());
                        var result = sqlCommand.ExecuteNonQuery();

                        if (result == 0)
                            throw new Exception("Erro ao gravar item da Nota Fiscal");
                    }
                    catch (Exception ex)
                    {
                        AddError("Erro ao gravar item da Nota Fiscal. details: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Grava uma lista de itens para nota fiscal
        /// </summary>
        /// <param name="items">Itens da nota fiscal</param>
        /// <param name="idNotaFiscal">Id da nota fiscal relacionado a o item</param>
        public void GravarItemNotaFiscal(IEnumerable<NotaFiscalItem> items, int idNotaFiscal)
        {
            foreach (var entity in items)
            {
                entity.IdNotaFiscal = idNotaFiscal;
                GravarItemNotaFiscal(entity);

                if (!IsValid)
                    return;
            }
        }
    }
}
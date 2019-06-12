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
    internal class NotaFiscalItemRepository : Notification, INotaFiscalItemRepository
    {
        private DbContext _dbContext;

        /// <summary>
        /// Grava um item da nota fiscal
        /// </summary>
        /// <param name="entity">Item da nota fiscal</param>
        private void GravarItemNotaFiscal(NotaFiscalItem entity)
        {
            using (_dbContext = new DbContext())
            {
                List<SqlParameter> parameterList = new List<SqlParameter>()
                    {
                        new SqlParameter() { ParameterName = "@pId",  Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@pIdNotaFiscal", Value = entity.IdNotaFiscal, SqlDbType = SqlDbType.Int },
                        new SqlParameter() { ParameterName = "@pCfop",Value = entity.Cfop, SqlDbType = SqlDbType.VarChar, Size = 5},
                        new SqlParameter() { ParameterName = "@pTipoIcms", Value = entity.TipoIcms, SqlDbType =  SqlDbType.VarChar, Size = 20},
                        new SqlParameter() { ParameterName = "@pBaseIcms", Value = entity.BaseIcms, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pAliquotaIcms", Value = entity.AliquotaIcms, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pValorIcms", Value = entity.ValorIcms, SqlDbType = SqlDbType.Decimal},
                        new SqlParameter() { ParameterName = "@pNomeProduto", Value = entity.NomeProduto, SqlDbType = SqlDbType.VarChar, Size = 50},
                        new SqlParameter() { ParameterName = "@pCodigoProduto", Value = entity.CodigoProduto, SqlDbType = SqlDbType.VarChar, Size = 50}
                    };

                using (SqlCommand sqlCommand = new SqlCommand("P_NOTA_FISCAL_ITEM", _dbContext.SqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(parameterList.ToArray());
                        var result = sqlCommand.ExecuteNonQuery();

                        if (result == 0)
                            AddError("Erro ao gravar item da Nota Fiscal");
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
            }
        }
    }
}
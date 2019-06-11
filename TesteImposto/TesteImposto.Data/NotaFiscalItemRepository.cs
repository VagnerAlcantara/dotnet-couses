using Locadora.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Repositories;

namespace TesteImposto.Data
{
    internal class NotaFiscalItemRepository : INotaFiscalItemRepository
    {
        private DbContext _dbContext;

        public void Add(NotaFiscalItem entity)
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
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(parameterList.ToArray());
                    var result = sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Add(IEnumerable<NotaFiscalItem> entities, int idNotaFiscal)
        {
            foreach (var entity in entities)
            {
                entity.IdNotaFiscal = idNotaFiscal;
                Add(entity);
            }
        }
    }
}
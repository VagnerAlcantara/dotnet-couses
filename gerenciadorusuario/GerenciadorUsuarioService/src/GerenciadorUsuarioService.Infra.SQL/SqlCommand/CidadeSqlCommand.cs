using Dapper;
using System.Data.Common;

namespace GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class CidadeSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandSelectById(string id)
        {
            _sql = @"SELECT 
	                    C.ID_CIDADE AS ID, 
	                    C.DS_CIDADE AS NOME 
                    FROM 
	                    CP_TBL_UF E  WITH (NOLOCK)
                    INNER JOIN 
	                    CP_TBL_CIDADE C  WITH (NOLOCK)
                    ON 
	                    E.CD_UF = C.CD_UF
                     WHERE 
	                    C.ID_CIDADE = @ID";

            object param = new
            {
                @ID = id
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectByUf(string uf)
        {
            _sql = @"SELECT 
	                    C.ID_CIDADE AS ID, 
	                    C.DS_CIDADE AS NOME 
                    FROM 
	                    CP_TBL_UF E WITH (NOLOCK)
                    INNER JOIN 
	                    CP_TBL_CIDADE C  WITH (NOLOCK)
                    ON 
	                    E.CD_UF = C.CD_UF
                     WHERE 
	                    E.CD_UF = @UF
                    ORDER BY 
	                    C.DS_CIDADE";

            object param = new
            {
                @UF = uf
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT 
	                    C.ID_CIDADE AS ID, 
	                    C.DS_CIDADE AS NOME 
                    FROM 
	                    CP_TBL_UF E WITH (NOLOCK)
                    INNER JOIN 
	                    CP_TBL_CIDADE C WITH (NOLOCK)
                    ON 
	                    E.CD_UF = C.CD_UF
                    ORDER BY 
	                    C.DS_CIDADE";

            return new CommandDefinition(_sql, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

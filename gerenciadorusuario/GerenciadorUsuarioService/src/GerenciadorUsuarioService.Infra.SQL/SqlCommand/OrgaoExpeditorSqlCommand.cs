using Dapper;
using System.Data.Common;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class OrgaoExpeditorSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandSelectById(string id)
        {
            _sql = @"SELECT 
	                    OREX_ID_ORGAO_EXPEDIDOR as id, 
	                    OREX_NOME_ORGAO_EXPEDIDOR as nome 
                    FROM 
	                    [CAD_ORGAO_EXPEDIDOR_OREX] WITH (NOLOCK)
                    WHERE 
	                    OREX_ID_ORGAO_EXPEDIDOR = @id";
            object param = new
            {
                @id = id
            };


            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT 
	                    OREX_ID_ORGAO_EXPEDIDOR as id, 
	                    OREX_NOME_ORGAO_EXPEDIDOR as nome 
                    FROM 
	                    [CAD_ORGAO_EXPEDIDOR_OREX] WITH (NOLOCK)";

            return new CommandDefinition(_sql, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

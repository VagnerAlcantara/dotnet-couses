using Dapper;
using System.Data.Common;

namespace GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class EstadoSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;

        internal CommandDefinition GetCommandSelectByUf(string uf)
        {
            _sql = @"SELECT 
	                    0 as Id, 
	                    DS_UF as Nome, 
	                    CD_UF as UF 
                    FROM 
	                    CP_TBL_UF WITH (NOLOCK)
                    WHERE 
	                    CD_UF = @UF 
                    ORDER BY 
	                    DS_UF ";

            object param = new
            {
                @UF = uf
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }

        
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT 
	                    0 as Id, 
	                    DS_UF as Nome, 
	                    CD_UF as UF 
                    FROM 
	                    CP_TBL_UF WITH (NOLOCK)
                    ORDER BY 
	                    DS_UF ";

            return new CommandDefinition(_sql, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

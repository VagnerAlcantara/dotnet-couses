using Dapper;
using System.Data.Common;

namespace GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class InstituicaoOrigemSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandSelectById(int id)
        {
            _sql = @"SELECT 
	                    CODINSTITUICAO AS ID, 
	                    DESCRINSTITUICAO AS NOME 
                    FROM 
	                    INSTITUICAO WITH (NOLOCK)
                    WHERE 
	                    CODINSTITUICAO = @id";
            object param = new
            {
                @id = id
            };


            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT 
	                    CODINSTITUICAO AS ID, 
	                    DESCRINSTITUICAO AS NOME 
                    FROM 
	                    INSTITUICAO WITH (NOLOCK)";

            return new CommandDefinition(_sql, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

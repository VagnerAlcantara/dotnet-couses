using Dapper;
using System.Data.Common;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class LogAcaoSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;

        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT 
                        [LLAC_ID]           AS Id
                        ,[LLAC_NOME_ACAO]   AS Nome
                    FROM 
                        [LOG_LDPMAN_ACOES_LLAC] WITH (NOLOCK)";

            return new CommandDefinition(_sql, null, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectById(int id)
        {
            _sql = @"SELECT 
                        [LLAC_ID]           AS Id
                        ,[LLAC_NOME_ACAO]   AS Nome
                    FROM 
                        [LOG_LDPMAN_ACOES_LLAC] WITH (NOLOCK)
                    WHERE
                        [LLAC_ID] = @Id";

            object param = new
            {
                @Id = id
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectByName(string name)
        {
            _sql = @"SELECT 
                        [LLAC_ID]           AS Id
                        ,[LLAC_NOME_ACAO]   AS Nome
                    FROM 
                        [LOG_LDPMAN_ACOES_LLAC] WITH (NOLOCK)
                    WHERE
                        [LLAC_NOME_ACAO] = @Name";

            object param = new
            {
                @Name = name
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandFilter(Dominio.Entidades.LogAcao logAcao)
        {
            _sql = @"SELECT 
	                    [LLAC_ID]           AS Id
                        ,[LLAC_NOME_ACAO]   AS Nome
                      FROM 
	                    [LOG_LDPMAN_ACOES_LLAC] WITH (NOLOCK)
                      WHERE
                        (
			              ([LLAC_ID] = @Id)
			              OR
			              (@Id IS NULL)
	                    )
                      AND
                        (
	                        ([LLAC_NOME_ACAO] = @Nome)
                            OR
                            (@Nome IS NULL)
                        )";


            object param = new
            {
                @Id = logAcao.Id,
                @Nome = logAcao.Nome,
            };

            return new CommandDefinition(_sql, null, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

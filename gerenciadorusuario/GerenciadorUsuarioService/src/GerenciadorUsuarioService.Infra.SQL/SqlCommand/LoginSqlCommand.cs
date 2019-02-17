using Dapper;
using System.Data;
using System.Data.Common;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class LoginSqlCommand
    {
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandLogin(string usuario, string senha)
        {
            _sql = @"DECLARE @ERRO VARCHAR(MAX) = null;
                     IF NOT EXISTS (
                      SELECT TOP 1
	                       [ID_CHAVE]
                      FROM 
	                    [dbo].[CHAVE_ACESSO] CA WITH (NOLOCK)
                      WHERE
	                    CA.[NOME_CHAVE] = @USUARIO
                      AND
	                    CA.[PASS_CHAVE] = @SENHA)
                      BEGIN
	                    SET @ERRO = 'Usuário " + usuario + @" do webservice não autorizado.'
                      END

                      IF(@ERRO IS NOT NULL)
                      BEGIN
	                    RAISERROR(@ERRO, 16, 1);
                      END"

                    ;

            var param = new
            {
                USUARIO = new DbString { Value = usuario, IsFixedLength = false, Length = 50, IsAnsi = true },
                SENHA = new DbString { Value = senha, IsFixedLength = false, Length = 50, IsAnsi = true }
            };

            return new CommandDefinition(_sql, parameters: param, transaction: null, commandType: CommandType.Text);

        }
    }
}

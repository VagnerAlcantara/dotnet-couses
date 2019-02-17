using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class ControleAcessoSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @"SELECT
	                    G.GRUP_ID_GRUPO AS ID,
	                    G.GRUP_NM_GRUPO AS NOME
                    FROM 
	                    [CA_SISTEMA_SIST] S WITH (NOLOCK)
                      INNER JOIN [CA_MODULO_MODU] M WITH (NOLOCK)
                      ON S.SIST_ID_SISTEMA = M.MODU_ID_SISTEMA 
                      INNER JOIN [CA_FUNCIONALIDADE_FUNC] F WITH (NOLOCK)
                      ON M.MODU_ID_MODULO = F.FUNC_ID_MODULO
                      INNER JOIN CA_OPERACAO_OPER O WITH (NOLOCK)
                      ON O.OPER_ID_FUNCIONALIDADE = F.FUNC_ID_FUNCIONALIDADE
                      INNER JOIN CA_GRUPO_OPERACAO_GROP GRO WITH (NOLOCK)
                      ON O.OPER_ID_OPERACAO = GRO.GROP_ID_OPERACAO
                      INNER JOIN CA_GRUPO_GRUP G WITH (NOLOCK)
                      ON GRO.GROP_ID_GRUPO = G.GRUP_ID_GRUPO
                    WHERE 
                      S.SIST_NM_SISTEMA = 'Gestão de dados no LDAP'";

            return new CommandDefinition(_sql, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }

        internal CommandDefinition GetCommandSelectByIdLdap(string idLdap)
        {
            _sql = @"SELECT
	                    G.GRUP_ID_GRUPO AS ID,
	                    G.GRUP_NM_GRUPO AS NOME
                      FROM [CA_SISTEMA_SIST] S WITH (NOLOCK)
                      INNER JOIN [CA_MODULO_MODU] M WITH (NOLOCK)
                      ON S.SIST_ID_SISTEMA = M.MODU_ID_SISTEMA
                      INNER JOIN [CA_FUNCIONALIDADE_FUNC] F WITH (NOLOCK)
                      ON M.MODU_ID_MODULO = F.FUNC_ID_MODULO
                      INNER JOIN CA_OPERACAO_OPER O WITH (NOLOCK)
                      ON O.OPER_ID_FUNCIONALIDADE = F.FUNC_ID_FUNCIONALIDADE
                      INNER JOIN CA_GRUPO_OPERACAO_GROP GRO WITH (NOLOCK)
                      ON O.OPER_ID_OPERACAO = GRO.GROP_ID_OPERACAO
                      INNER JOIN CA_GRUPO_GRUP G  WITH (NOLOCK)
                      ON GRO.GROP_ID_GRUPO = G.GRUP_ID_GRUPO
                      INNER JOIN CA_GRUPO_USUARIO_GRUS GRUS WITH (NOLOCK)
                      ON GRUS.GRUS_ID_GRUPO = G.GRUP_ID_GRUPO
                      INNER JOIN CA_USUARIO_USUA U WITH (NOLOCK)
                      ON GRUS.GRUS_ID_USUARIO = U.USUA_ID_USUARIO
                    WHERE 
	                    S.SIST_NM_SISTEMA = 'Gestão de dados no LDAP'
                    AND 
	                    U.USUA_ID_LDAP = @idLdap";

            object param = new
            {
                @idLdap = idLdap
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

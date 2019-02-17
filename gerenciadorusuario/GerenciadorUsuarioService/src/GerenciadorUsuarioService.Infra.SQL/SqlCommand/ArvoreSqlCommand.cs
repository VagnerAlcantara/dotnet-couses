using Dapper;
using System.Data.Common;

namespace  GerenciadorUsuarioService.Infra.SQL.SqlCommand
{
    public class ArvoreSqlCommand
    {
        public DbTransaction _transaction;
        public string _sql = string.Empty;
        internal CommandDefinition GetCommandSelectById(string id)
        {
            _sql = @" SELECT 
                           [ID_ARVORE] as Id
                          ,[DS_ARVORE] as Nome
                          ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as OU
                          ,[VALIDACPF] as ValidaCPF
                          ,[ALTERARG]  as RGAlteraSenha
                      FROM [ARVORE_LDAP] WITH (NOLOCK)
                      WHERE [ID_ARVORE] = @ID";

            object param = new
            {
                @ID = id
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectByName(string nome)
        {
            _sql = @" SELECT 
                           [ID_ARVORE] as Id
                          ,[DS_ARVORE] as Nome
                          ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as OU
                          ,[VALIDACPF] as ValidaCPF
                          ,[ALTERARG]  as RGAlteraSenha
                      FROM [ARVORE_LDAP] WITH (NOLOCK)
                      WHERE [DS_ARVORE] = @NOME";

            object param = new
            {
                @NOME = nome
            };

            return new CommandDefinition(_sql, parameters: param, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
        internal CommandDefinition GetCommandSelectAll()
        {
            _sql = @" SELECT 
                           [ID_ARVORE] as Id
                          ,[DS_ARVORE] as Nome
                          ,(SUBSTRING(ds_arvore, 0,(SELECT CHARINDEX(',o=', ds_arvore)))) as OU
                          ,[VALIDACPF] as ValidaCPF
                          ,[ALTERARG]  as RGAlteraSenha
                      FROM [ARVORE_LDAP] WITH (NOLOCK)";

            return new CommandDefinition(_sql, transaction: this._transaction, commandType: System.Data.CommandType.Text);
        }
    }
}

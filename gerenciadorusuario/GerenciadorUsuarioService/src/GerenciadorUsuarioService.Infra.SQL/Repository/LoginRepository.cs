using Dapper;
using GerenciadorUsuarioService.Infra.SQL.Database;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;
using System;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class LoginRepository 
    {
        public void Login(string usuario, string senha)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
            {
                try
                {
                    cn.Query<Dominio.Entidades.Usuario>(new LoginSqlCommand().GetCommandLogin(usuario, senha));
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao logar: ", ex.Message));
                }
            }
        }
      

    }
}

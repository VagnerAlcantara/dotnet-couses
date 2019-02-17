using Dapper;
using GerenciadorUsuarioService.Infra.SQL.Database;
using System;
using System.Linq;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;
namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class InstituicaoOrigemRepository : GerenciadorUsuarioService.Dominio.Interfaces.IInstituicaoOrigemRepository
    {
        public Dominio.Entidades.InstituicaoOrigem ObterInstituicaoOrigemPorId(int id)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
            {
                try
                {
                    return cn.Query<Dominio.Entidades.InstituicaoOrigem>(new InstituicaoOrigemSqlCommand().GetCommandSelectById(id)).FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter instituição de origem: ", ex.Message));
                }
            }
        }

        public System.Collections.Generic.IEnumerable<Dominio.Entidades.InstituicaoOrigem> ObterTodos()
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
            {
                try
                {
                    return cn.Query<Dominio.Entidades.InstituicaoOrigem>(new InstituicaoOrigemSqlCommand().GetCommandSelectAll());
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter instituição de origem: ", ex.Message));
                }
            }
        }
     
    }
}

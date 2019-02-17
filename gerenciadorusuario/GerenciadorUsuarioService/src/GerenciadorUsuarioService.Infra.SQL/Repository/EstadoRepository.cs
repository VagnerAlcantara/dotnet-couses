using GerenciadorUsuarioService.Dominio.Interfaces;
using GerenciadorUsuarioService.Infra.SQL.Database;
using System;
using System.Linq;
using Dapper;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class EstadoRepository : IEstadoRepository
    {
    

        public Dominio.Entidades.Estado ObterEstadorPorUf(string uf)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionRsdbcorp())
            {
                try
                {
                    return cn.Query<Dominio.Entidades.Estado>(new EstadoSqlCommand().GetCommandSelectByUf(uf)).FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao buscar estado: ", ex.Message));
                }
            }
        }

        public System.Collections.Generic.IEnumerable<Dominio.Entidades.Estado> ObterTodos()
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionRsdbcorp())
            {
                try
                {
                    return cn.Query<Dominio.Entidades.Estado>(new EstadoSqlCommand().GetCommandSelectAll());
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao buscar estado: ", ex.Message));
                }
            }
        }
    }
}

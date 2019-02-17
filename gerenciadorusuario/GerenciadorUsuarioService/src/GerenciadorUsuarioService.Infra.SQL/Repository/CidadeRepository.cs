using Dapper;
using GerenciadorUsuarioService.Dominio.Entidades;
using GerenciadorUsuarioService.Dominio.Interfaces;
using GerenciadorUsuarioService.Infra.SQL.Database;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        public Cidade ObterCidadePorId(string id)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionRsdbcorp())
            {
                try
                {
                    return cn.Query<Dominio.Entidades.Cidade>(new CidadeSqlCommand().GetCommandSelectById(id)).FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao buscar cidade: ", ex.Message));
                }
            }
        }

        public IEnumerable<Cidade> ObterCidadePorUf(string uf)
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionRsdbcorp())
            {
                try
                {
                    return cn.Query<Cidade>(new CidadeSqlCommand().GetCommandSelectByUf(uf));
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao buscar cidade: ", ex.Message));
                }
            }
        }

        public IEnumerable<Cidade> ObterTodos()
        {
            using (var cn = SqlDatabaseConnection.GetOpenConnectionRsdbcorp())
            {
                try
                {
                    return cn.Query<Cidade>(new CidadeSqlCommand().GetCommandSelectAll());
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao buscar cidade: ", ex.Message));
                }
            }
        }

    }
}

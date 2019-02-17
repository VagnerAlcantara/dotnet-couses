using GerenciadorUsuarioService.Dominio.Entidades;
using GerenciadorUsuarioService.Dominio.Interfaces;
using GerenciadorUsuarioService.Infra.SQL.Database;
using  GerenciadorUsuarioService.Infra.SQL.SqlCommand;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class ArvoreRepository : IArvoreRepository
    {
        public Arvore ObterArvorePorId(string id)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
                {
                    return cn.Query<Dominio.Entidades.Arvore>(new ArvoreSqlCommand().GetCommandSelectById(id)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Árvore por Id: " + ex.Message);
            }
        }

        public Arvore ObterArvorePorNome(string nome)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
                {
                    return cn.Query<Dominio.Entidades.Arvore>(new ArvoreSqlCommand().GetCommandSelectByName(nome)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Árvore por Nome: " + ex.Message);
            }
        }

        public IEnumerable<Arvore> ObterTodos()
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
                {
                    return cn.Query<Dominio.Entidades.Arvore>(new ArvoreSqlCommand().GetCommandSelectAll()).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Árvore: " + ex.Message);
            }
        }
    

    }
}

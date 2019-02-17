using Dapper;
using GerenciadorUsuarioService.Dominio.Entidades;
using GerenciadorUsuarioService.Dominio.Interfaces;
using GerenciadorUsuarioService.Infra.SQL.ControleAcesso;
using GerenciadorUsuarioService.Infra.SQL.Database;
using GerenciadorUsuarioService.Infra.SQL.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorUsuarioService.Infra.SQL.Repository
{
    public class ControleAcessoRepository : IControleAcessoRepository
    {
        private ControleAcessoSoapClient _controleAcessoSoapClient { get; set; }

        public ControleAcessoRepository()
        {
            _controleAcessoSoapClient = new ControleAcessoSoapClient();
        }
        public bool ChecaPermissao(string lcpt, string siglaFuncionalidade, string ipCliente, ref string msgErro)
        {
            return _controleAcessoSoapClient.ChecaPermissaoPorFuncionalidade(lcpt, siglaFuncionalidade, ipCliente, ref msgErro);
        }

        public ICollection<string> ObterOperacoes(string lcpt, string siglaFuncionalidade, string ipCliente, ref string msgErro)
        {
            return _controleAcessoSoapClient.GetOperacoesPorFuncionalidade(lcpt, siglaFuncionalidade, ipCliente, ref msgErro).ToList<string>();
        }

        public Boolean AtualizaControleAcesso(Int32 idLdap, IEnumerable<Int32> idsGrupo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grupo> ObterGrupos()
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
                {
                    return cn.Query<Grupo>(new ControleAcessoSqlCommand().GetCommandSelectAll()).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Árvore por Id: " + ex.Message);
            }
        }

        public IEnumerable<Grupo> ObterGruposPorIdLdap(int idLdap)
        {
            try
            {
                using (var cn = SqlDatabaseConnection.GetOpenConnectionPecReceptor())
                {
                    return cn.Query<Dominio.Entidades.Grupo>(new ControleAcessoSqlCommand().GetCommandSelectByIdLdap(idLdap.ToString())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Árvore por Id: " + ex.Message);
            }
        }

      
    }
}

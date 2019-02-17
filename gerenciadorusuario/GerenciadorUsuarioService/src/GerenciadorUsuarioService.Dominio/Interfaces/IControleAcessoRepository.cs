using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IControleAcessoRepository 
    {
        bool ChecaPermissao(string lcpt, string siglaFuncionalidade, string ipCliente, ref string msgErro);

        ICollection<string> ObterOperacoes(string lcpt, string siglaFuncionalidade, string ipCliente, ref string msgErro);

        Boolean AtualizaControleAcesso(Int32 idLdap, IEnumerable<Int32> idsGrupo);

        IEnumerable<Grupo> ObterGrupos();

        IEnumerable<Grupo> ObterGruposPorIdLdap(int idLdap);
    }
}

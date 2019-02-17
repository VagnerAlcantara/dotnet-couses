using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface ILdapRepository 
    {
        Usuario Adicionar(Usuario usuario, bool gerarLog);
        Usuario Atualizar(Usuario usuario, bool gerarLog);
        Usuario AtualizarComSenha(Usuario usuario, bool gerarLog);
        void RestaurarSenha(string idLdap, bool gerarLog);
        void Remover(string idLdap, bool gerarLog);
        ICollection<Usuario> Buscar(Usuario filtro, Boolean todasPropriedades);
        Usuario Buscar(String idLdap, Boolean todasPropriedades);

    }
}

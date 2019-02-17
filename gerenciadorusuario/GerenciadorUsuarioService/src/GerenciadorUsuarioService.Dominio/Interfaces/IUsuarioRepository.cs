using GerenciadorUsuarioService.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Adicionar(Usuario usuario, bool gerarLog);

        Usuario Atualizar(Usuario usuario, bool gerarLog);
        void AtualizarSenha(string idLdap, string senha, bool gerarLog);
        Usuario AtualizarComSenha(Usuario usuario, bool gerarLog);

        void RestaurarSenha(string idLdap, bool gerarLog);
        void Remover(string idLdap, bool gerarLog);
        ICollection<Usuario> Buscar(Usuario filtro, Boolean todasPropriedades);
        ICollection<Usuario> Buscar(Usuario filtro, Op operador);
        ICollection<Usuario> Buscar(ICollection<string> idsLdap, bool todasPropriedades);
        ICollection<Usuario> Buscar(ICollection<string> cpfs);
        Usuario Buscar(string idLdap);

        Usuario Login(Usuario filtro);
        Usuario LoginByCpf(string cpf, string password);
        Usuario LoginByName(string name, string password);
    }
}

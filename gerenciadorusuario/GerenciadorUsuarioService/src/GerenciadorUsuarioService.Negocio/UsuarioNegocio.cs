using GerenciadorUsuarioService.Dominio.Entidades;
using GerenciadorUsuarioService.Infra.SQL.Repository;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioNegocio()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public Usuario Login(Usuario usuario)
        {
            return _usuarioRepository.Login(usuario);
        }

        public Usuario LoginByCpf(string cpf, string password)
        {
            return _usuarioRepository.LoginByCpf(cpf, password);
        }

        public Usuario LoginByName(string name, string password)
        {
            return _usuarioRepository.LoginByName(name, password);
        }

        public Usuario Adicionar(Usuario model)
        {
            return _usuarioRepository.Adicionar(model, false);
        }

        public Usuario ObterPorIdLdap(string IdLdap)
        {
            return _usuarioRepository.Buscar(IdLdap);
        }

        public Usuario Atualizar(Usuario model)
        {
            return _usuarioRepository.Atualizar(model, false);
        }

        public void AtualizarSenha(string idLdap, string senha)
        {
            _usuarioRepository.AtualizarSenha(idLdap, senha, false);
        }

        public ICollection<Usuario> Filter(Usuario usuario, Op operador)
        {
            return _usuarioRepository.Buscar(usuario, operador);
        }

        public ICollection<Usuario> Filter(ICollection<string> idsLdap)
        {
            return _usuarioRepository.Buscar(idsLdap, true);
        }

        public ICollection<Usuario> FilterByCpf(ICollection<string> cpfs)
        {
            return _usuarioRepository.Buscar(cpfs);
        }

        //public void Delete(string idLdap)
        //{
        //    _ldapRepository.Remover(idLdap, false);
        //}



        //public Usuario SelectByIdLdap(string IdLdap)
        //{
        //    return _ldapRepository.Buscar(IdLdap, true);
        //}
        //public Usuario Login(Usuario usuario)
        //{
        //    return _ldapRepository.Login(usuario);
        //}



    }
}

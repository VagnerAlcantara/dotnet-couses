using System;
using System.Linq;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly YouLearnContext _context;

        public RepositoryUsuario(YouLearnContext context)
        {
            _context = context;
        }

        public bool Existe(string email)
        {
            return _context.Usuarios.Any(x => string.Equals(x.Email.Endereco.ToLower(), email.ToLower()));
        }

        public Usuario Obter(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario Obter(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault
            (x =>
                string.Equals(x.Email.Endereco.ToLower(), email.ToLower()) &&
                string.Equals(x.Senha.Valor.ToLower(), senha.ToLower())
            );

        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }
    }
}

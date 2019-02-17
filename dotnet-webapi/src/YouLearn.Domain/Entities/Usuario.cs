using YouLearn.Domain.Base;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {
        protected Usuario()
        {

        }
        public Usuario(Email email, Senha senha)
        {
            Email = email;
            Senha = senha;

            AddNotifications(email, senha);
        }

        public Usuario(Nome nome, Email email, Senha senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            AddNotifications(nome, email, senha);
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
    }
}

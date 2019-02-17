using TWApp.Dominio.ObjetosDeValor;
using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string login, Senha senha)
        {
            Login = login;
            Senha = senha;
            Ativo = true;
        }

        public string Login { get; private set; }
        public Senha Senha { get; private set; }
        public bool Ativo { get; private set; }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}

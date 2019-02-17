using TWApp.Compartilhado.Entidades;
using TWApp.Dominio.ObjetosDeValor;

namespace TWApp.Dominio.Entidades
{
    public class Contato : Entidade
    {
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }

        public Contato(Telefone telefone, Email email)
        {
            Email = email;
            Telefone = telefone;
        }
    }
}

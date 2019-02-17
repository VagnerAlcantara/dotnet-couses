using TWApp.Compartilhado.Entidades;
using TWApp.Dominio.ObjetosDeValor;

namespace TWApp.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public Cep Cep { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public Endereco(Cep cep, string numero, string complemento)
        {
            Cep = cep;
            Numero = numero;
            Complemento = complemento;

            if (string.IsNullOrEmpty(numero))
                AdicionarNotificacao("Endereco.Numero", "Número do endereço é obrigatório");
        }
    }
}

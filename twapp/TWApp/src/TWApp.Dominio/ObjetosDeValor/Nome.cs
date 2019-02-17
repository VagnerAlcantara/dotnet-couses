using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Nome : ObjetoDeValor
    {

        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            if (string.IsNullOrEmpty(PrimeiroNome))
                AdicionarNotificacao("Primeiro nome", "Primeiro nome é obrigatório");

            if (string.IsNullOrEmpty(Sobrenome))
                AdicionarNotificacao("Sobrenome", "Sobrenome é obrigatório");

        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public override string ToString()
        {
            return $"{PrimeiroNome} {Sobrenome}";
        }
    }
}

using System.Text.RegularExpressions;
using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Cep : ObjetoDeValor
    {
        private readonly Regex regex = new Regex(@"^\d{5}\d{3}$");

        public string Numero { get; private set; }

        public Cep(string numero)
        {
            Numero = numero;

            if (!regex.IsMatch(Numero))
                AdicionarNotificacao("Cep.Numero", "CEP inválido");
        }

    }
}

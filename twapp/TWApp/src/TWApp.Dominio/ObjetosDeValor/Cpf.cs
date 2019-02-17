using System.Text.RegularExpressions;
using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Cpf: ObjetoDeValor
    {
        private readonly Regex regex = new Regex(@"([0 - 9]{ 2}[\.]?[0 - 9]{3}[\.]?[0 - 9]{3}[\/]?[0 - 9]{4}[-]?[0 - 9]{2})|([0 - 9]{3}[\.]?[0 - 9]{3}[\.]?[0 - 9]{3}[-]?[0 - 9]{2})");

        public Cpf(string numero)
        {
            Numero = numero;

            if (string.IsNullOrEmpty(numero))
                AdicionarNotificacao("Cpf.Numero","Cpf é obrigatório");

            if (!regex.IsMatch(numero))
                AdicionarNotificacao("Cpf.Numero", "Cpf inválido");

        }

        public string Numero { get; private set; }

    }
}

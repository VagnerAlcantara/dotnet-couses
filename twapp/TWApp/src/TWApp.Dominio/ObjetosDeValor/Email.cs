using System.Text.RegularExpressions;
using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Email : ObjetoDeValor
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            if (!Regex.IsMatch(Endereco, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                AdicionarNotificacao("E-mail", "E-mail inválido");


            if (string.IsNullOrEmpty(endereco))
                AdicionarNotificacao("E-mail", "E-mail obrigatório");
        }

        public string Endereco { get; private set; }
    }
}

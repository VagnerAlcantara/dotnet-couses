using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.ObjetosDeValor
{
    public class Rg : ObjetoDeValor
    {
        public Rg(string numero)
        {
            Numero = numero;

            if (string.IsNullOrEmpty(numero))
                AdicionarNotificacao("RG", "RG é obrigatório");
        }

        public string Numero { get; private set; }
    }
}

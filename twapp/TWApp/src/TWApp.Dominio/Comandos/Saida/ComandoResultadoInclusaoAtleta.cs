using TWApp.Compartilhado.Comandos;

namespace TWApp.Dominio.Comandos.Saida
{
    public class ComandoResultadoInclusaoAtleta : IResultadoComando
    {
        public ComandoResultadoInclusaoAtleta(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}

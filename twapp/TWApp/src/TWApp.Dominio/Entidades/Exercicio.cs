using TWApp.Compartilhado.Entidades;

namespace TWApp.Dominio.Entidades
{
    public class Exercicio : Entidade
    {
        public Exercicio(string nome, int serie, string repeticao, string carga)
        {
            Nome = nome;
            Serie = serie;
            Repeticao = repeticao;
            Carga = carga;
        }

        public string Nome { get; private set; }
        public int Serie { get; private set; }
        public string Repeticao { get; private set; }
        public string Carga { get; private set; }
    }
}

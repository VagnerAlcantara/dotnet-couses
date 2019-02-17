namespace Locadora.Domain.Entities
{
    public class Filme
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public int Ano { get; private set; }

        public Filme(int? id, string nome, int anoLancamento)
        {
            if (id.HasValue)
                Id = id.Value;

            this.Titulo = nome;
            this.Ano= anoLancamento;
        }
    }
}

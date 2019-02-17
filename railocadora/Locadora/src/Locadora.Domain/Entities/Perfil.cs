namespace Locadora.Domain.Entities
{
    public class Perfil
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public Perfil(string nome, bool ativo)
        {
            this.Nome = nome;
            this.Ativo = ativo;
        }
    }
}

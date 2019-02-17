namespace Locadora.Domain.Entities
{
    public class Permissao
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdPerfil { get; private set; }
    }
}

namespace CursoAspNetMvc5.Domain
{
    public class Telefone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public virtual TipoTelefone Tipo { get; set; }
    }
}

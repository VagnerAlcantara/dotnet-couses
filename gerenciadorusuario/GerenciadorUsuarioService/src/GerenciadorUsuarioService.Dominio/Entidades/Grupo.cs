
namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class Grupo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Selecionado { get; set; }
    }
}

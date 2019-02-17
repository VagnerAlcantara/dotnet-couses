
namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class LogCamposAlterados
    {
        public int Id { get; set; }
        public int IdLog { get; set; }
        public string Campo { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public virtual Log cLog { get; set; }
    }
}

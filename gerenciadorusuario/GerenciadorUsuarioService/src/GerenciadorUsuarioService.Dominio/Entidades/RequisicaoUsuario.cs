namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class RequisicaoUsuario
    {
        public RequisicaoUsuario()
        {

        }
        public RequisicaoUsuario(Usuario usuario, Seguranca seguranca)
        {
            Usuario = usuario;
            Seguranca = seguranca;
        }

        public Usuario Usuario { get; private set; }
        public Seguranca Seguranca { get; private set; }

    }
}

using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class RetornoUsuario
    {
        public RetornoUsuario()
        {

        }
        public RetornoUsuario(Usuario usuario, List<Usuario> usuarios, Status status)
        {
            Usuario = usuario;
            Usuarios = usuarios;
            Status = status;
        }

        public Usuario Usuario { get; private set; }
        public List<Usuario> Usuarios { get; private set; }
        public Status Status { get; private set; }

    }
}

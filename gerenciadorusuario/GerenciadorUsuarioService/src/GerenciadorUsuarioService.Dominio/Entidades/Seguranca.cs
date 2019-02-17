namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class Seguranca
    {
        public Seguranca()
        {

        }
        public Seguranca(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public string Usuario { get; private set; }
        public string Senha { get; private set; }
    }
}

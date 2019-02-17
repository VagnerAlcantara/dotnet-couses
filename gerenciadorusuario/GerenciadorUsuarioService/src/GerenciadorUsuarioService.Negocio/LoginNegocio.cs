using GerenciadorUsuarioService.Infra.SQL.Repository;

namespace GerenciadorUsuarioService.Negocio
{
    public class LoginNegocio
    {
        private readonly LoginRepository _loginRepository;

        public LoginNegocio()
        {
            _loginRepository = new LoginRepository();
        }

        public void Login(string usuario, string senha)
        {
            _loginRepository.Login(usuario, senha);
        }
       
    }
}

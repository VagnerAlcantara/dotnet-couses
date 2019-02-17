using GerenciadorUsuarioService.WebService;
using GerenciadorUsuarioService.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GerenciadorUsuarioService.WebServiceTests
{
    [TestClass()]
    public class UsuarioServiceTests
    {

        UsuarioService _usuarioService = new UsuarioService();

        #region| Testes - Criar usuário

        [TestMethod()]
        [TestCategory("Usuario - Criar")]
        public void Dado_Um_Usuario_Valido_Deve_Gravar()
        {

            Usuario usuario = new Usuario
            {
                IDLDAP = null,
                IdArvore = 0,
                Nome = "UsuarioService",
                RG = "CIMA-88888",
                CPF = "CIMA-88888",
                Email = "email@email.com"
            };

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.CriarUsuario(requisicaoUsuario);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Criar")]
        public void Dado_Um_Usuario_Com_CPF_Existente_Deve_Retornar_Erro()
        {

            Usuario usuario = new Usuario
            {
                IDLDAP = null,
                IdArvore = 0,
                Nome = "UsuarioService",
                RG = "CIMA-888881",
                CPF = "CIMA-88888",
                Email = "email1@email.com"
            };

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.CriarUsuario(requisicaoUsuario);

            Assert.IsFalse(result.Status.Success, result.Status.ErrorMessage);
        }

        [TestMethod()]
        [TestCategory("Usuario - Criar")]
        public void Dado_Um_Usuario_Com_RG_Existente_Deve_Retornar_Erro()
        {

            Usuario usuario = new Usuario
            {
                IDLDAP = null,
                IdArvore = 0,
                Nome = "UsuarioService",
                RG = "CIMA-88888",
                CPF = "CIMA-888881",
                Email = "email1@email.com"
            };

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.CriarUsuario(requisicaoUsuario);

            Assert.IsFalse(result.Status.Success, result.Status.ErrorMessage);
        }

        [TestMethod()]
        [TestCategory("Usuario - Criar")]
        public void Dado_Um_Usuario_Com_Email_Existente_Deve_Retornar_Erro()
        {

            Usuario usuario = new Usuario
            {
                IDLDAP = null,
                IdArvore = 0,
                Nome = "UsuarioService",
                RG = "CIMA-888881",
                CPF = "CIMA-888881",
                Email = "email@email.com"
            };

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.CriarUsuario(requisicaoUsuario);

            Assert.IsFalse(result.Status.Success, result.Status.ErrorMessage);
        }

        #endregion

        #region| Testes - Atualizar usuário

        [TestMethod()]
        [TestCategory("Usuario - Atualizar")]
        public void Dado_Um_Usuario_Valido_Deve_Atualizar()
        {
            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            Usuario usuario = new Usuario
            {
                CPF = "CIMA-88888"
            };

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var resultUsuario = _usuarioService.RetornaUsuarios(requisicaoUsuario, Op.AND);

            Usuario usuarioUpdate = resultUsuario.Usuarios.FirstOrDefault();

            usuarioUpdate.Nome = "Teste atualização";

            RequisicaoUsuario requisicaoUsuarioUpdate = new RequisicaoUsuario(usuarioUpdate, seguranca);

            var result = _usuarioService.AtualizarUsuario(requisicaoUsuarioUpdate);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Atualizar")]
        public void Dado_Uma_Senha_Valida_Deve_Atualizar()
        {
            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            Usuario usuario = new Usuario
            {
                //CPF = "CIMA-88888",
                IDLDAP = "525471",
                Senha = "NG04ecfyYDg="
            };

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.AtualizarSenha(requisicaoUsuario);

            Assert.IsTrue(result.Status.Success);
        }

        #endregion

        #region| Testes - Login

        [TestMethod()]
        [TestCategory("Usuario - Login")]
        public void Dado_Um_LoginDE_Valido_Deve_Logar()
        {

            Usuario usuario = new Usuario
            {
                IDLDAP = "DE-10102",
                Senha = "NG04ecfyYDg="
            };

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.Login(requisicaoUsuario);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Login")]
        public void Dado_Um_LoginCIMA_Valido_Deve_Logar()
        {

            Usuario usuario = new Usuario();
            usuario.IDLDAP = "CIMA-94929";
            usuario.Senha = "NG04ecfyYDg=";

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.Login(requisicaoUsuario);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Login")]
        public void Dado_Um_LoginRG_Valido_Deve_Logar()
        {

            Usuario usuario = new Usuario();
            usuario.IDLDAP = "16508391";
            usuario.Senha = "NG04ecfyYDg=";

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.Login(requisicaoUsuario);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Login")]
        public void Dado_Um_LoginCpf_Valido_Deve_Logar()
        {

            Usuario usuario = new Usuario();
            usuario.IDLDAP = "04779431875";
            usuario.Senha = "NG04ecfyYDg=";

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.Login(requisicaoUsuario);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Login")]
        public void Dado_Um_LoginNome_Valido_Deve_Logar()
        {

            Usuario usuario = new Usuario
            {
                IDLDAP = "MARIA APARECIDA EUSEBIO DE OLIVEIRA",
                Senha = "NG04ecfyYDg="
            };

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.Login(requisicaoUsuario);

            Assert.IsNotNull(result);
        }

        #endregion

        #region| Testes - Buscas

        [TestMethod()]
        [TestCategory("Usuario - Buscas")]
        public void Dado_Um_IdLdap_Valido_Deve_Retornar_Um_Usuario()
        {

            Usuario usuario = new Usuario();
            usuario.IDLDAP = "6749";
            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            var result = _usuarioService.RetornaUsuarios(requisicaoUsuario, Op.AND);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Buscas")]
        public void Dado_Uma_Lista_IDLDAP_Valido_Deve_Retornar_Uma_Lista_Usuario()
        {

            Usuario usuario = new Usuario();

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            string[] idsLdap = { "6749", "6751", "6755", "6756" };

            var result = _usuarioService.RetornaUsuariosPorListaLdap(requisicaoUsuario, idsLdap);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [TestCategory("Usuario - Buscas")]
        public void Dado_Uma_Lista_CPF_Valido_Deve_Retornar_Uma_Lista_Usuario()
        {

            Usuario usuario = new Usuario();

            Seguranca seguranca = new Seguranca("CN=ROOT", "NG04ecfyYDg=");

            RequisicaoUsuario requisicaoUsuario = new RequisicaoUsuario(usuario, seguranca);

            string[] cpfs = { "04779431875", "99063085834", "15013338875" };

            var result = _usuarioService.RetornaUsuariosPorListaCpf(requisicaoUsuario, cpfs);

            Assert.IsNotNull(result);
        }

        #endregion
    }
}
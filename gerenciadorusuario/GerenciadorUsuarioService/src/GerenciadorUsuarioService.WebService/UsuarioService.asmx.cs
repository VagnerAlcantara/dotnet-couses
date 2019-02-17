using GerenciadorUsuarioService.Dominio.Entidades;
using GerenciadorUsuarioService.Dominio.Validacao;
using GerenciadorUsuarioService.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace GerenciadorUsuarioService.WebService
{
    /// <summary>
    /// Summary description for UsuarioService
    /// </summary>
    [WebService(Namespace = "Usuario")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UsuarioService : System.Web.Services.WebService
    {
        LoginNegocio _loginNegocio;
        UsuarioNegocio _usuarioNegocio;

        public UsuarioService()
        {
            _loginNegocio = new LoginNegocio();
            _usuarioNegocio = new UsuarioNegocio();
        }

        #region|Login

        [WebMethod(MessageName = "Login", Description = "Método responsável pela autenticação na base de usuários.")]
        public RetornoUsuario Login(RequisicaoUsuario requisicao)
        {
            try
            {
                if (string.IsNullOrEmpty(requisicao.Usuario.IDLDAP) || string.IsNullOrEmpty(requisicao.Usuario.Senha))
                    return new RetornoUsuario(requisicao.Usuario, null, new Status(3, "Usuário/Senha em branco.", false));

                if (CPF.IsValid(requisicao.Usuario.IDLDAP) ||
                    (
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("DE-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("ESC-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("EFAP-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("CGRH-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("CGEB-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("CIMA-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("CISE-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("COFI-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("CEE-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("DA-") ||
                    requisicao.Usuario.IDLDAP.ToUpper().Contains("GS-"))
                    )
                    requisicao.Usuario.CPF = requisicao.Usuario.IDLDAP;
                else if (RG.IsValid(requisicao.Usuario.IDLDAP))
                    requisicao.Usuario.RG = requisicao.Usuario.IDLDAP;
                else
                    requisicao.Usuario.Nome = requisicao.Usuario.IDLDAP;

                requisicao.Usuario.IDLDAP = null;

                Usuario usuario = _usuarioNegocio.Login(requisicao.Usuario);

                if (usuario.IDLDAP != "0" && !String.IsNullOrEmpty(usuario.IDLDAP))
                    return new RetornoUsuario(usuario, null, new Status(0, "", true));
                else
                    return new RetornoUsuario(usuario, null, new Status(3, "Usuário não encontrado", false));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Ops"))
                    return new RetornoUsuario(requisicao.Usuario, null, new Status(66, ex.Message, false));
                else
                    return new RetornoUsuario(requisicao.Usuario, null, new Status(3, ex.Message, false));
            }


        }

        /*
        [WebMethod(MessageName = "Login by Cpf", Description = "Método que verifica no LDAP By Cpf as informações de um usuário comum.")]
        public RetornoUsuario LoginByCpf(string cpf, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(password))
                    return new RetornoUsuario(null, null, new Status(3, "Usuário/Senha em branco.", false));

                Usuario usuario = _usuarioAppService.LoginByCpf(cpf, password);

                if (string.Equals(usuario.IDLDAP, "0") || String.IsNullOrEmpty(usuario.IDLDAP))
                    return new RetornoUsuario(null, null, new Status(3, "Usuário não encontrado", false));

                return new RetornoUsuario(usuario, null, new Status(0, "", true));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Ops"))
                    return new RetornoUsuario(null, null, new Status(66, ex.Message, false));
                else
                    return new RetornoUsuario(null, null, new Status(3, ex.Message, false));
            }
        }

        [WebMethod(MessageName = "Login by Name", Description = "Método que verifica no LDAP By Name as informações de um usuário comum.")]
        public RetornoUsuario LoginByName(string name, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
                    return new RetornoUsuario(null, null, new Status(3, "Usuário/Senha em branco.", false));

                Usuario usuario = _usuarioAppService.LoginByName(name, password);

                if (string.Equals(usuario.IDLDAP, "0") || String.IsNullOrEmpty(usuario.IDLDAP))
                    return new RetornoUsuario(null, null, new Status(3, "Usuário não encontrado", false));

                return new RetornoUsuario(usuario, null, new Status(0, "", true));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Ops"))
                    return new RetornoUsuario(null, null, new Status(66, ex.Message, false));
                else
                    return new RetornoUsuario(null, null, new Status(3, ex.Message, false));
            }
        }
        */
        #endregion

        #region| CRUD

        [WebMethod(MessageName = "CriarUsuario", Description = "Método responsável pela inclusão de um novo usuário")]
        public RetornoUsuario CriarUsuario(RequisicaoUsuario requisicao)
        {
            try
            {
                //Valida usuário do web service
                _loginNegocio.Login(requisicao.Seguranca.Usuario, requisicao.Seguranca.Senha);

                requisicao.Usuario.IdArvore = 0;

                var usuario = _usuarioNegocio.Adicionar(requisicao.Usuario);

                if (usuario.IDLDAP != "0")
                    return new RetornoUsuario(usuario, null, new Status(0, "", true));
                else
                    return new RetornoUsuario(null, null, new Status(0, "Ocorreu um erro ao incluir o usuário.", false));


            }
            catch (Exception ex)
            {
                return new RetornoUsuario(requisicao.Usuario, null, new Status(0, "Ocorreu um erro ao incluir o usuário. - " + ex.Message, false));
            }

        }

        [WebMethod(MessageName = "AtualizarUsuario", Description = "Método responsável pela atualização de dados de um determinado usuário")]
        public RetornoUsuario AtualizarUsuario(RequisicaoUsuario requisicao)
        {
            try
            {
                //Valida usuário do web service
                _loginNegocio.Login(requisicao.Seguranca.Usuario, requisicao.Seguranca.Senha);

                requisicao.Usuario.IdArvore = 0;

                var existeUsuario = _usuarioNegocio.ObterPorIdLdap(requisicao.Usuario.IDLDAP).IDLDAP;

                if (string.IsNullOrEmpty(existeUsuario))
                    return new RetornoUsuario(null, null, new Status(13, "Usuário Id, " + requisicao.Usuario.IDLDAP + " não encontrado.", false));

                _usuarioNegocio.Atualizar(requisicao.Usuario);

                return new RetornoUsuario(requisicao.Usuario, null, new Status(0, "", true));


            }
            catch (Exception ex)
            {
                return new RetornoUsuario(requisicao.Usuario, null, new Status(10, "Ocorreu um erro ao atualizar o usuário. - " + ex.Message, false));
            }

        }

        [WebMethod(MessageName = "AtualizarSenha", Description = "Método responsável pela atualização de senha de um determinado usuário")]
        public RetornoUsuario AtualizarSenha(RequisicaoUsuario requisicao)
        {
            try
            {
                _usuarioNegocio.AtualizarSenha(requisicao.Usuario.IDLDAP, requisicao.Usuario.Senha);

                return new RetornoUsuario(null, null, new Status(0, "", true));
            }
            catch (Exception ex)
            {
                return new RetornoUsuario(null, null, new Status(0, ex.Message, false));
            }

        }

        #endregion


        #region | Busca com RetornoUsuario

        [WebMethod(MessageName = "RetornaUsuarios", Description = "Método que pesquisa um ou mais registros na base de dados de usuário dado parametros de pesquisa e retorna ArrayList dos dados.")]
        public RetornoUsuario RetornaUsuarios(RequisicaoUsuario req, Op op)
        {
            try
            {
                _loginNegocio.Login(req.Seguranca.Usuario, req.Seguranca.Senha);

                req.Usuario.IdArvore = 0;

                if (!string.IsNullOrEmpty(req.Usuario.CPF))
                    req.Usuario.CPF = req.Usuario.CPF.Replace("*", "");
                if (!string.IsNullOrEmpty(req.Usuario.RG))
                    req.Usuario.RG = req.Usuario.RG.Replace("*", "");
                if (!string.IsNullOrEmpty(req.Usuario.Nome))
                    req.Usuario.Nome = req.Usuario.Nome.Replace("*", "");

                var result = _usuarioNegocio.Filter(req.Usuario, op);

                object[] users = new object[result.Count];

                if (result.Count == 0)
                    return new RetornoUsuario(null, null, new Status(0, "", true));
                else
                    if (result.Count > 1 || result != null)
                    return new RetornoUsuario(null, result.ToList(), new Status(0, "", true));
                else
                    return new RetornoUsuario(result.FirstOrDefault(), result.ToList(), new Status(0, "", true));

            }
            catch (Exception ex)
            {
                return new RetornoUsuario(null, null, new Status(40, ex.Message, false));
            }

        }

        [WebMethod(MessageName = "RetornaUsuariosPorListaLdap", Description = "Método que retorna uma lista de usuários com base no idldap")]
        public RetornoUsuario RetornaUsuariosPorListaLdap(RequisicaoUsuario req, string[] idsLdap)
        {
            try
            {
                _loginNegocio.Login(req.Seguranca.Usuario, req.Seguranca.Senha);

                ICollection<Usuario> users = _usuarioNegocio.Filter(idsLdap).ToList();

                if (users.Count == 0)
                    return new RetornoUsuario(null, null, new Status(0, "", true));
                else
                    return new RetornoUsuario(null, users.ToList(), new Status(0, "", true));

            }
            catch (Exception ex)
            {
                return new RetornoUsuario(null, null, new Status(40, ex.Message, false));
            }

        }

        [WebMethod(MessageName = "RetornaUsuariosPorListaCpf", Description = "Método que retorna uma lista de usuários com base no cpf")]
        public RetornoUsuario RetornaUsuariosPorListaCpf(RequisicaoUsuario req, string[] cpfs)
        {
            try
            {
                _loginNegocio.Login(req.Seguranca.Usuario, req.Seguranca.Senha);

                ICollection<Usuario> users = _usuarioNegocio.FilterByCpf(cpfs).ToList();

                if (users.Count == 0)
                    return new RetornoUsuario(null, null, new Status(0, "", true));
                else
                    return new RetornoUsuario(null, users.ToList(), new Status(0, "", true));

            }
            catch (Exception ex)
            {
                return new RetornoUsuario(null, null, new Status(40, ex.Message, false));
            }

        }

        #endregion
    }
}


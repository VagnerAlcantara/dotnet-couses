using System;
using System.Collections.Generic;
using System.Web;

namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class UsuarioLogado
    {
        public UsuarioLogado()
        {
            Operacoes = new List<string>();
        }

        public String Id { get; set; }
        public String Cpf { get; set; }
        public String Nome { get; set; }
        public String Rg { get; set; }
        public String Email { get; set; }
        public ICollection<string> Operacoes { get; set; }


        /// <summary>
        /// Gravar usuário na sessão
        /// </summary>
        /// <param name="usuarioLogado"></param>
        public static void Gravar(UsuarioLogado usuarioLogado)
        {
            try
            {
                HttpContext.Current.Session[HttpContext.Current.Session.SessionID + "_UsuarioLogado"] = usuarioLogado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtém usuário da sessão
        /// </summary>
        /// <param name="usuarioLogado"></param>
        public static UsuarioLogado Obter()
        {
            try
            {
                if (HttpContext.Current.Session[HttpContext.Current.Session.SessionID + "_UsuarioLogado"] != null)
                    return (UsuarioLogado)HttpContext.Current.Session[HttpContext.Current.Session.SessionID + "_UsuarioLogado"];
                else
                    return null;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Remove o usuario usuário da sessão
        /// </summary>
        /// <param name="usuarioLogado"></param>
        public static void Atualizar(UsuarioLogado usuarioLogado)
        {
            try
            {
                if (HttpContext.Current.Session[HttpContext.Current.Session.SessionID + "_UsuarioLogado"] != null)
                    HttpContext.Current.Session.Remove(HttpContext.Current.Session.SessionID + "_UsuarioLogado");

                HttpContext.Current.Session[HttpContext.Current.Session.SessionID + "_UsuarioLogado"] = usuarioLogado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using Locadora.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locadora.UI.WebForms.Forms.Cliente
{
    public partial class Alterar : System.Web.UI.Page
    {
        private ClienteBusiness _clienteBusiness;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string cpf = Request.QueryString["cpf"];

                if(string.IsNullOrEmpty(cpf))
                    this.Response.Redirect("Index.aspx");


                try
                {
                    var result = _clienteBusiness.Obter(cpf);
                    this.hfIdCliente.Value = result.Id.ToString();
                    this.txtNomeCliente.Text = result.Nome;
                    this.txtCpfCliente.Text = result.Cpf;
                    this.txtDataNascimento.Text = result.DataNascimento.Date.ToShortDateString();
                    this.txtEmailCliente.Text = result.Email;
                    this.txtTelefoneCliente.Text = result.Telefone;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Alterar()
        {
            _clienteBusiness = new ClienteBusiness();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.Entities.Cliente cliente = new Domain.Entities.Cliente(Convert.ToInt32(this.hfIdCliente.Value),
                    Convert.ToInt32(Convert.ToInt32(new Random().Next(0, 1000))),
                    true,
                    txtCpfCliente.Text,
                    null,
                    txtNomeCliente.Text,
                    Convert.ToDateTime(txtDataNascimento.Text), txtTelefoneCliente.Text, txtEmailCliente.Text);

                _clienteBusiness.Alterar(cliente);

                msgSucesso.Visible = true;
                msgSucesso.InnerText = "Cliente alterado com sucesso";
            }
            catch (Exception ex)
            {
                msgErro.Visible = true;
                msgErro.InnerText = ex.Message;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Index.aspx");
        }
    }
}
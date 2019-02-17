using Locadora.BLL;
using System;

namespace Locadora.UI.WebForms.Forms.Cliente
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        private ClienteBusiness _clienteBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            msgErro.Visible = false;
            msgSucesso.Visible = false;
        }

        public Cadastrar()
        {
            _clienteBusiness = new ClienteBusiness();

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.Entities.Cliente cliente = new Domain.Entities.Cliente(null,
                    Convert.ToInt32(Convert.ToInt32(new Random().Next(0, 1000))),
                    true,
                    txtCpfCliente.Text,
                    null,
                    txtNomeCliente.Text,
                    Convert.ToDateTime(txtDataNascimento.Text), txtTelefoneCliente.Text, txtEmailCliente.Text);

                _clienteBusiness.Adicionar(cliente);

                msgSucesso.Visible = true;
                msgSucesso.InnerText = "Cliente adicionado com sucesso";
            }
            catch (Exception ex)
            {
                msgErro.Visible = true;
                msgErro.InnerText = ex.Message;
            }
        }
    }
}
using Locadora.BLL;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Locadora.UI.WebForms.Forms.Cliente
{
    public partial class Index : System.Web.UI.Page
    {
        private ClienteBusiness _clienteBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            msgErro.Visible = false;
            msgSucesso.Visible = false;
            gdvClientes.DataSource = null;
        }

        public Index()
        {
            _clienteBusiness = new ClienteBusiness();
        }


        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _clienteBusiness.Obter(txtCpfCliente.Text);

                if (result == null)
                {
                    msgErro.Visible = true;
                    msgErro.InnerText = "Cliente não encontrado";
                }
                else
                {
                    IList<Domain.Entities.Cliente> clienteList = new List<Domain.Entities.Cliente>();
                    clienteList.Add(result);
                    gdvClientes.DataSource = clienteList;
                    gdvClientes.DataBind();
                }

            }
            catch (Exception ex)
            {
                msgErro.Visible = true;
                msgErro.InnerText = ex.Message;
            }
        }


        protected void gdvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editar"))
            {
                string cpf = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(cpf))
                    this.Response.Redirect("Alterar.aspx?cpf=" + cpf);
            }

            if (e.CommandName.Equals("Locacao"))
            {
                string idCliente = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(idCliente))
                    this.Response.Redirect(@"..\Locacao\Locacao.aspx?id=" + idCliente);
            }
        }


    }
}
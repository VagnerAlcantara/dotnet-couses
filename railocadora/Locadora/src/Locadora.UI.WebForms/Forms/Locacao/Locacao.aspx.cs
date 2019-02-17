using Locadora.BLL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locadora.UI.WebForms.Forms.Locacao
{
    public partial class Locacao : Page
    {
        private LocacaoBusiness _locacaoBusiness;
        private ClienteBusiness _clienteBusiness;
        private FilmeBusiness _filmeBusiness;

        public Locacao()
        {
            _locacaoBusiness = new LocacaoBusiness();
            _clienteBusiness = new ClienteBusiness();
            _filmeBusiness = new FilmeBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string idCliente = Request.QueryString["id"];

            if (string.IsNullOrEmpty(idCliente))
                this.Response.Redirect("./Index.aspx");


            try
            {
                var resultCliente = _clienteBusiness.Obter(Convert.ToInt32(idCliente));
                this.txtCpfCliente.Text = resultCliente.Cpf;
                this.txtNomeCliente.Text = resultCliente.Nome;
                this.hfIdCliente.Value = resultCliente.Id.ToString();
                Session[string.Concat(Session.SessionID, "_idCliente")] = resultCliente.Id.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (!IsPostBack)
            {
                try
                {
                    CarregarGrid(Convert.ToInt32(idCliente));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void CarregarGrid(int idCliente)
        {
            var result = _locacaoBusiness.ObterPorCliente(idCliente);

            IList<Domain.Entities.Locacao> locacaoList = new List<Domain.Entities.Locacao>();
            locacaoList = result;
            IList<ModelForm.GridLocacaoViewForm> gridModel = new List<ModelForm.GridLocacaoViewForm>();
            foreach (var item in locacaoList)
            {
                var filme = _filmeBusiness.Obter(item.IdFilme);

                gridModel.Add(new ModelForm.GridLocacaoViewForm()
                {
                    Id = item.Id,
                    Titulo = filme.Titulo,
                    DataRetirada = item.DataRetirada,
                    DataEntrega = item.DataEntrega
                });
            }

            
            gdvLocacao.DataSource = gridModel;
            gdvLocacao.DataBind();
        }

        protected void gdvLocacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("RemoverLocacao"))
            {
                string id = e.CommandArgument.ToString();
                if (String.IsNullOrEmpty(id))
                    this.Response.Redirect("./Locacao.aspx?id=" + Session[string.Concat(Session.SessionID, "_idCliente")]);

                try
                {
                    _locacaoBusiness.Excluir(Convert.ToInt32(id));


                    int idCliente = Convert.ToInt32(Session[string.Concat(Session.SessionID, "_idCliente")]);
                    CarregarGrid(Convert.ToInt32(idCliente));
                    msgSucesso.Visible = true;
                    msgSucesso.InnerText = "Locação excluída com sucesso.";
                }
                catch (Exception)
                {
                    msgErro.Visible = true;
                    msgErro.InnerText = "Erro ao excluir locação.";
                }

            }

        }

        protected void btnAlugar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("./Alugar.aspx?idcliente=" + Session[string.Concat(Session.SessionID, "_idCliente")]);
        }
    }
}
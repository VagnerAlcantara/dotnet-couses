using Locadora.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locadora.UI.WebForms.Forms.Locacao
{
    public partial class Alugar : System.Web.UI.Page
    {
        private FilmeBusiness _filmeBusiness;
        private ClienteBusiness _clienteBusiness;
        private LocacaoBusiness _locacaoBusiness;

        public Alugar()
        {
            _filmeBusiness = new FilmeBusiness();
            _clienteBusiness = new ClienteBusiness();
            _locacaoBusiness = new LocacaoBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["idcliente"];

            if (string.IsNullOrEmpty(id))
                id = Session[string.Concat(Session.SessionID, "_idCliente")].ToString();

            if (string.IsNullOrEmpty(id))
                this.Response.Redirect("./cliente/Index.aspx");

            try
            {
                var resultCliente = _clienteBusiness.Obter(Convert.ToInt32(id));
                this.txtCpfCliente.Text = resultCliente.Cpf;
                this.txtNomeCliente.Text = resultCliente.Nome;
                this.hfIdCliente.Value = resultCliente.Id.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (!IsPostBack)
            {
                var filmes = _filmeBusiness.Obter();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Titulo"), new DataColumn("Ano") });
                foreach (var filme in filmes)
                {
                    dt.Rows.Add(filme.Id, filme.Titulo, filme.Ano);
                }
                gdvFilme.DataSource = dt;
                gdvFilme.DataBind();
            }


        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            IList<Domain.Entities.Filme> filmes = null;

            if (string.IsNullOrEmpty(txtTituloFilme.Text))
                filmes = _filmeBusiness.Obter();
            else
                filmes = _filmeBusiness.Obter(txtTituloFilme.Text);

            gdvFilme.DataSource = filmes;
            gdvFilme.DataBind();
        }


        protected void btnAlugarSelecionado_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gdvFilme.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string idCliente = Session[string.Concat(Session.SessionID, "_idCliente")].ToString();
                        string idFilme = row.Cells[1].Text;


                        var jaAlugado = _locacaoBusiness.ObterPorCliente(Convert.ToInt32(idCliente)).Where(x => x.IdFilme == Convert.ToInt32(idFilme));

                        if (jaAlugado == null || jaAlugado.Count() == 0)
                        {
                            _locacaoBusiness.Adicionar(new Domain.Entities.Locacao(
                                null,
                                Convert.ToInt32(idFilme),
                                Convert.ToInt32(idCliente), DateTime.Now, DateTime.Now.AddDays(5)));

                            msgSucesso.Visible = true;
                            msgSucesso.InnerText = "Filme alugado com sucesso.";
                        }
                        else
                        {
                            msgErro.Visible = true;
                            msgErro.InnerText = "Filme já alugado";
                        }
                    }
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("./Locacao.aspx?id=" + Session[string.Concat(Session.SessionID, "_idCliente")]);
        }
    }
}
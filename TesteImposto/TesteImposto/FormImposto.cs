using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TesteImposto.Domain;
using TesteImposto.Service;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private NotaFiscalService _notaFiscalService;
        private readonly string msgCaption = "Teste Imposto";

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private void FormImposto_Load(object sender, EventArgs e)
        {
            CarregarComboEstadoOrigem();
            CarregarComboEstadoDestino();
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));
            return table;
        }

        private void ButtonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                Pedido pedido = null;
                try
                {
                    pedido = CriarPedido();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro inesperado ao criar pedido, por favor, confirme os dados e tente novamente", msgCaption);
                }

                if (!pedido.IsValid)
                {
                    string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", pedido.Errors.Select(i => i).ToArray()));
                    MessageBox.Show(msgInfo, msgCaption);
                    return;
                }

                try
                {
                    _notaFiscalService = new NotaFiscalService();

                    _notaFiscalService.GerarNotaFiscal(pedido);
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro inesperado ao criar gerar nota fiscal, por favor, confirme os dados e tente novamente", msgCaption);
                }
                

                if (_notaFiscalService.IsValid)
                {
                    MessageBox.Show("Operação efetuada com sucesso!", msgCaption);
                    RestaurarTela();
                    return;
                }
                else
                {
                    string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", _notaFiscalService.Errors.Select(i => i).ToArray()));
                    MessageBox.Show(msgInfo, msgCaption);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro inesperado, por favor, tente novamente mais tarde", msgCaption);
                return;
            }
        }

        /// <summary>
        /// Recupera e cria pedido informado pelo usuário
        /// </summary>
        private Pedido CriarPedido()
        {
            string ufOrigem = string.Empty;
            string ufDestino = string.Empty;

            if (cbEstadoOrigem.SelectedValue != null)
                ufOrigem = cbEstadoOrigem.SelectedValue.ToString();

            if (cbEstadoDestino.SelectedValue != null)
                ufDestino = cbEstadoDestino.SelectedValue.ToString();

            IList<PedidoItem> pedidoItems = CriarItemsPedido();

            return new Pedido(ufOrigem, ufDestino, textBoxNomeCliente.Text, pedidoItems);
        }

        /// <summary>
        /// Recupera e cria itens do pedido informado pelo usuário
        /// </summary>
        private IList<PedidoItem> CriarItemsPedido()
        {
            List<PedidoItem> pedidoItem = new List<PedidoItem>();

            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            foreach (DataRow row in table.Rows)
            {
                string nomeProduto = row["Nome do produto"] == null ? string.Empty : row["Nome do produto"].ToString();
                string codProduto = row["Codigo do produto"] == null ? string.Empty : row["Codigo do produto"].ToString();
                double valorProduto = row["Valor"] == null ? 0 : Convert.ToDouble(row["Valor"].ToString());
                bool brinde = false;

                if (row["Brinde"] == null)
                    bool.TryParse(row["Brinde"].ToString(), out brinde);

                pedidoItem.Add(new PedidoItem(nomeProduto, codProduto, valorProduto, brinde));
            }

            return pedidoItem;
        }

        /// <summary>
        /// Limpa a tela
        /// </summary>
        public void RestaurarTela()
        {
            CarregarComboEstadoOrigem();
            CarregarComboEstadoDestino();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            textBoxNomeCliente.Text = string.Empty;
        }
        
        /// <summary>
        /// Carrega o combo de estado origem
        /// </summary>
        public void CarregarComboEstadoOrigem()
        {
            cbEstadoOrigem.DataSource = Estado.GetEstados();
            cbEstadoOrigem.DisplayMember = "Value";
            cbEstadoOrigem.ValueMember = "Key";
            cbEstadoOrigem.SelectedValue = "";
        }

        /// <summary>
        /// Carrega o combo de estado destino
        /// </summary>
        public void CarregarComboEstadoDestino()
        {
            cbEstadoDestino.DataSource = Estado.GetEstados();
            cbEstadoDestino.DisplayMember = "Value";
            cbEstadoDestino.ValueMember = "Key";
            cbEstadoDestino.SelectedValue = "";

        }
    }
}

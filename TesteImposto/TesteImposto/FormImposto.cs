using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TesteImposto.Domain;
using TesteImposto.Service;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private Pedido _pedido;
        private NotaFiscalService _notaFiscalService;

        private void FormImposto_Load(object sender, EventArgs e)
        {
            CarregarComboEstadoOrigem();
            CarregarComboEstadoDestino();
        }

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private void ButtonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                CriarPedido();
                CriarItemsPedido();

                if (!_pedido.IsValid)
                    return;

                _notaFiscalService = new NotaFiscalService();

                _notaFiscalService.GerarNotaFiscal(_pedido);

                if (_notaFiscalService.IsValid)
                {
                    MessageBox.Show("Operação efetuada com sucesso");
                    RestaurarTela();
                    return;
                }
                else
                {
                    string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", _notaFiscalService.Errors.Select(i => i).ToArray()));
                    MessageBox.Show(msgInfo, "Atenção");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao gerar nota fiscal");
                return;
            }

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

        /// <summary>
        /// Recupera e cria itens do pedido informado pelo usuário
        /// </summary>
        private void CriarItemsPedido()
        {
            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            foreach (DataRow row in table.Rows)
            {
                string nomeProduto = row["Nome do produto"] == null ? string.Empty : row["Nome do produto"].ToString();
                string codProduto = row["Codigo do produto"] == null ? string.Empty : row["Codigo do produto"].ToString();
                double valorProduto = row["Valor"] == null ? 0 : Convert.ToDouble(row["Valor"].ToString());
                bool brinde = false;

                if (row["Brinde"] == null)
                {
                    bool.TryParse(row["Brinde"].ToString(), out brinde);
                }
                    
                     

                PedidoItem pedidoItem = new PedidoItem(nomeProduto, codProduto, valorProduto, brinde);

                if (pedidoItem.IsValid)
                    _pedido.AddItem(pedidoItem);
            }
        }

        /// <summary>
        /// Recupera e cria pedido informado pelo usuário
        /// </summary>
        private void CriarPedido()
        {
            string ufOrigem = string.Empty;
            string ufDestino = string.Empty;

            if (cbEstadoOrigem.SelectedValue != null)
                ufOrigem = cbEstadoOrigem.SelectedValue.ToString();

            if (cbEstadoDestino.SelectedValue != null)
                ufDestino = cbEstadoDestino.SelectedValue.ToString();

            _pedido = new Pedido(ufOrigem, ufDestino, textBoxNomeCliente.Text);

            if (!_pedido.IsValid)
            {
                string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", _pedido.Errors.Select(i => i).ToArray()));
                MessageBox.Show(msgInfo);
                return;
            }
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

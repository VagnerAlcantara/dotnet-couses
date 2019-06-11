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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar pedido");
                return;
            }

            try
            {
                CriarItemsPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar itens pedido");
                return;
            }

            try
            {
                if (!_pedido.IsValid)
                {
                    MessageBox.Show("Erro ao gerar nota fiscal");
                    return;
                }

                NotaFiscalService notaFiscalService = new NotaFiscalService();

                notaFiscalService.GerarNotaFiscal(_pedido);

                if (notaFiscalService.IsValid)
                {
                    MessageBox.Show("Operação efetuada com sucesso");
                    return;
                }
                else
                {
                    string msgInfo = string.Concat("Atenção!\nErro ao gerar nota fiscal!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", notaFiscalService.Errors.Select(i => i).ToArray()));
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
                PedidoItem pedidoItem = new PedidoItem(
                    row["Nome do produto"] == null ? string.Empty : row["Nome do produto"].ToString(),
                    row["Codigo do produto"] == null ? string.Empty : row["Codigo do produto"].ToString(),
                    row["Valor"] == null ? 0 : Convert.ToDouble(row["Valor"].ToString()),
                    row["Brinde"] == null ? false : Convert.ToBoolean(row["Brinde"])
                );

                if (pedidoItem.IsValid)
                    _pedido.AddItem(pedidoItem);
            }
        }

        /// <summary>
        /// Recupera e cria pedido informado pelo usuário
        /// </summary>
        private void CriarPedido()
        {
            _pedido = new Pedido(txtEstadoDestino.Text, txtEstadoOrigem.Text, textBoxNomeCliente.Text);

            if (!_pedido.IsValid)
            {
                string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", _pedido.Errors.Select(i => i).ToArray()));
                MessageBox.Show(msgInfo);
                return;
            }
        }

    }
}

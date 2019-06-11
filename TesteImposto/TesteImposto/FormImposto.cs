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

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
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

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            Pedido pedido = new Pedido(txtEstadoDestino.Text, txtEstadoOrigem.Text, textBoxNomeCliente.Text);

            if (!pedido.IsValid)
            {
                string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", pedido.Errors.Select(i => i).ToArray()));
                MessageBox.Show(msgInfo);
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                PedidoItem pedidoItem = new PedidoItem(
                    row["Nome do produto"] == null ? string.Empty : row["Nome do produto"].ToString(),
                    row["Codigo do produto"] == null ? string.Empty : row["Codigo do produto"].ToString(),
                    row["Valor"] == null ? 0 : Convert.ToDouble(row["Valor"].ToString()),
                    row["Brinde"] == null ? false : Convert.ToBoolean(row["Brinde"])
                );

                if (pedidoItem.IsValid)
                    pedido.AddItem(pedidoItem);
            }

            NotaFiscalService service = new NotaFiscalService();
            service.GerarNotaFiscal(pedido);
            MessageBox.Show("Operação efetuada com sucesso");
        }

    }
}

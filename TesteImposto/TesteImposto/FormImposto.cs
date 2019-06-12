﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                {
                    MessageBox.Show("Erro ao gerar nota fiscal");
                    return;
                }

                _notaFiscalService = new NotaFiscalService();

                _notaFiscalService.GerarNotaFiscal(_pedido);

                if (_notaFiscalService.IsValid)
                {
                    MessageBox.Show("Operação efetuada com sucesso");
                    return;
                }
                else
                {
                    string msgInfo = string.Concat("Atenção!\nErro ao gerar nota fiscal!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", _notaFiscalService.Errors.Select(i => i).ToArray()));
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
        /// Lista de estados
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<KeyValuePair<string, string>> GetEstados()
        {
            return new ObservableCollection<KeyValuePair<string, string>>()
            {
            new KeyValuePair<string, string>( "AC", "Acre" ),
            new KeyValuePair<string, string>( "AL", "Alagoas" ),
            new KeyValuePair<string, string>( "AP", "Amapá" ),
            new KeyValuePair<string, string>( "AM", "Amazonas" ),
            new KeyValuePair<string, string>( "BA", "Bahia" ),
            new KeyValuePair<string, string>( "CE", "Ceará" ),
            new KeyValuePair<string, string>( "DF", "Distrito Federal" ),
            new KeyValuePair<string, string>( "ES", "Espírito Santo" ),
            new KeyValuePair<string, string>( "GO", "Goiás" ),
            new KeyValuePair<string, string>( "MA", "Maranhão" ),
            new KeyValuePair<string, string>( "MT", "Mato Grosso" ),
            new KeyValuePair<string, string>( "MS", "Mato Grosso do Sul" ),
            new KeyValuePair<string, string>( "MG", "Minas Gerais" ),
            new KeyValuePair<string, string>( "PA", "Pará" ),
            new KeyValuePair<string, string>( "PB", "Paraíba" ),
            new KeyValuePair<string, string>( "PR", "Paraná" ),
            new KeyValuePair<string, string>( "PE", "Pernambuco" ),
            new KeyValuePair<string, string>( "PI", "Piauí" ),
            new KeyValuePair<string, string>( "RJ", "Rio de Janeiro" ),
            new KeyValuePair<string, string>( "RN", "Rio Grande do Norte" ),
            new KeyValuePair<string, string>( "RS", "Rio Grande do Sul" ),
            new KeyValuePair<string, string>( "RO", "Rondônia" ),
            new KeyValuePair<string, string>( "RR", "Roraima" ),
            new KeyValuePair<string, string>( "SC", "Santa Catarina" ),
            new KeyValuePair<string, string>( "SP", "São Paulo" ),
            new KeyValuePair<string, string>( "SE", "Sergipe" ),
            new KeyValuePair<string, string>( "TO", "Tocantins" )
            };
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
            _pedido = new Pedido(cbEstadoOrigem.SelectedValue.ToString(), cbEstadoDestino.SelectedValue.ToString(), textBoxNomeCliente.Text);

            if (!_pedido.IsValid)
            {
                string msgInfo = string.Concat("Atenção!\nPor favor, corrigir os seguintes itens: \n", string.Join("\n", _pedido.Errors.Select(i => i).ToArray()));
                MessageBox.Show(msgInfo);
                return;
            }
        }
    }
}

using System.Collections.Generic;

namespace TesteImposto.Domain
{
    public class Pedido : BaseDomain
    {
        public string EstadoDestino { get; private set; }
        public string EstadoOrigem { get; private set; }
        public string NomeCliente { get; private set; }
        public List<PedidoItem> ItensDoPedido { get; private set; }

        private Pedido() => ItensDoPedido = new List<PedidoItem>();

        public Pedido(string estadoDestino, string estadoOrigem, string nomeCliente)
            : this()
        {
            ValidarPedido(estadoDestino, estadoOrigem, nomeCliente);

            if (IsValid)
            {
                EstadoDestino = estadoDestino;
                EstadoOrigem = estadoOrigem;
                NomeCliente = nomeCliente;
            }
        }
        private void ValidarPedido(string estadoDestino, string estadoOrigem, string nomeCliente)
        {
            if (string.IsNullOrEmpty(estadoDestino))
                AddError("Estado destino é obrigatório");

            if (string.IsNullOrEmpty(estadoOrigem))
                AddError("Estado origem é obrigatório");

            if (string.IsNullOrEmpty(nomeCliente))
                AddError("Nome cliente é obrigatório");
        }
        public void AddItem(PedidoItem item)
        {
            if (item.IsValid)
            {
                AddError("Item inválido");
                return;
            }
            ItensDoPedido.Add(item);
        }
    }
}

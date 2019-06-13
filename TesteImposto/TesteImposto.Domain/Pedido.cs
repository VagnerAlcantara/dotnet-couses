using System.Collections.Generic;
using TesteImposto.Shared;

namespace TesteImposto.Domain
{
    /// <summary>
    /// Pedido de compra
    /// </summary>
    public class Pedido : Notification
    {
        public string EstadoDestino { get; private set; }
        public string EstadoOrigem { get; private set; }
        public string NomeCliente { get; private set; }
        public IList<PedidoItem> ItensDoPedido { get; private set; }

        private Pedido() => ItensDoPedido = new List<PedidoItem>();

        public Pedido(string estadoOrigem, string estadoDestino, string nomeCliente, IList<PedidoItem> itensDoPedido) : this()
        {
            ValidatePedido(estadoDestino, estadoOrigem, nomeCliente, itensDoPedido);

            if (IsValid)
                CreatePedido(estadoDestino, estadoOrigem, nomeCliente, itensDoPedido);
        }
        /// <summary>
        /// Valida um pedido
        /// </summary>
        /// <param name="estadoDestino">Estado de destino do pedido</param>
        /// <param name="estadoOrigem">Estado de origem do pedido</param>
        /// <param name="nomeCliente">Nome do cliente que esta realizando o pedido</param>
        /// <param name="itensDoPedido">Itens relacionado ao pedido</param>
        private void ValidatePedido(string estadoDestino, string estadoOrigem, string nomeCliente, IList<PedidoItem> itensDoPedido)
        {
            if (string.IsNullOrEmpty(estadoDestino))
                AddError("Estado destino é obrigatório");

            if (string.IsNullOrEmpty(estadoOrigem))
                AddError("Estado origem é obrigatório");

            if (string.IsNullOrEmpty(nomeCliente))
                AddError("Nome cliente é obrigatório");

            if (itensDoPedido == null || itensDoPedido.Count == 0)
                AddError("É obrigatório o preenchimento de ao menos um item para o pedido");
        }

        /// <summary>
        /// Cria um pedido
        /// </summary>
        /// <param name="estadoDestino">Estado de destino do pedido</param>
        /// <param name="estadoOrigem">Estado de origem do pedido</param>
        /// <param name="nomeCliente">Nome do cliente que esta realizando o pedido</param>
        /// <param name="itensDoPedido">Itens relacionado ao pedido</param>
        private void CreatePedido(string estadoDestino, string estadoOrigem, string nomeCliente, IList<PedidoItem> itensDoPedido)
        {
            EstadoDestino = estadoDestino;
            EstadoOrigem = estadoOrigem;
            NomeCliente = nomeCliente;
            ItensDoPedido = itensDoPedido;
        }

        /// <summary>
        /// Adiciona itens válidos a um pedido
        /// </summary>
        /// <param name="item">Item do pedido</param>
        public void AddItem(PedidoItem item)
        {
            if (!item.IsValid)
                AddError(item.Errors);
            else
                ItensDoPedido.Add(item);
        }
    }
}

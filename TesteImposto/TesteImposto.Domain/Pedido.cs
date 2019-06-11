using System.Collections.Generic;

namespace TesteImposto.Domain
{
    /// <summary>
    /// Pedido de compra
    /// </summary>
    public class Pedido : BaseDomain
    {
        public string EstadoDestino { get; private set; }
        public string EstadoOrigem { get; private set; }
        public string NomeCliente { get; private set; }
        public IList<PedidoItem> ItensDoPedido { get; private set; }

        private Pedido() => ItensDoPedido = new List<PedidoItem>();

        public Pedido(string estadoDestino, string estadoOrigem, string nomeCliente) : this()
        {
            ValidatePedido(estadoDestino, estadoOrigem, nomeCliente);

            if (IsValid)
                CreatePedido(estadoDestino, estadoOrigem, nomeCliente);
        }
        
        /// <summary>
        /// Cria um pedido
        /// </summary>
        /// <param name="estadoDestino">Estado de destino do pedido</param>
        /// <param name="estadoOrigem">Estado de origem do pedido</param>
        /// <param name="nomeCliente">Nome do cliente que esta realizando o pedido</param>
        private void CreatePedido(string estadoDestino, string estadoOrigem, string nomeCliente)
        {
            EstadoDestino = estadoDestino;
            EstadoOrigem = estadoOrigem;
            NomeCliente = nomeCliente;
        }
        
        /// <summary>
        /// Valida um pedido
        /// </summary>
        /// <param name="estadoDestino">Estado de destino do pedido</param>
        /// <param name="estadoOrigem">Estado de origem do pedido</param>
        /// <param name="nomeCliente">Nome do cliente que esta realizando o pedido</param>
        private void ValidatePedido(string estadoDestino, string estadoOrigem, string nomeCliente)
        {
            if (string.IsNullOrEmpty(estadoDestino))
                AddError("Estado destino é obrigatório");

            if (string.IsNullOrEmpty(estadoOrigem))
                AddError("Estado origem é obrigatório");

            if (string.IsNullOrEmpty(nomeCliente))
                AddError("Nome cliente é obrigatório");
        }
        
        /// <summary>
        /// Adiciona itens válidos a um pedido
        /// </summary>
        /// <param name="item">Item do pedido</param>
        public void AddItem(PedidoItem item)
        {
            if (!item.IsValid)
            {
                AddError(item.Errors);
                return;
            }
            ItensDoPedido.Add(item);
        }
    }
}

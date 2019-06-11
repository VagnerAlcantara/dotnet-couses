namespace TesteImposto.Domain
{
    /// <summary>
    /// Item para geração de um pedido
    /// </summary>
    public class PedidoItem : BaseDomain
    {
        public string NomeProduto { get; private set; }
        public string CodigoProduto { get; private set; }
        public double ValorItemPedido { get; private set; }
        public bool Brinde { get; private set; }

        public PedidoItem(string nomeProduto, string codigoProduto, double valorItemPedido, bool brinde = false)
        {
            ValidateItem(nomeProduto, codigoProduto, valorItemPedido);

            if (IsValid)
                CreateItem(nomeProduto, codigoProduto, valorItemPedido);
        }
        /// <summary>
        /// Cria um item de pedido
        /// </summary>
        /// <param name="nomeProduto">Nome do produto</param>
        /// <param name="codigoProduto">Código do produto</param>
        /// <param name="valorItemPedido">Valor do item</param>
        /// <param name="brinde"></param>
        private void CreateItem(string nomeProduto, string codigoProduto, double valorItemPedido, bool brinde = false)
        {
            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
            ValorItemPedido = valorItemPedido;
            Brinde = brinde;
        }
        /// <summary>
        /// Valida um item de pedido
        /// </summary>
        /// <param name="nomeProduto">Nome do produto</param>
        /// <param name="codigoProduto">Código do produto</param>
        /// <param name="valorItemPedido">Valor do item de pedido</param>
        private void ValidateItem(string nomeProduto, string codigoProduto, double valorItemPedido)
        {
            if (string.IsNullOrEmpty(nomeProduto))
                AddError("Nome do produto é obrigatório");

            if (string.IsNullOrEmpty(codigoProduto))
                AddError("Código produto é obrigatório");

            if (valorItemPedido < 0 || valorItemPedido > int.MaxValue)
                AddError("Valor do produto inválido");
        }
    }
}

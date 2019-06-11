namespace TesteImposto.Domain
{
    public class PedidoItem : BaseDomain
    {
        public PedidoItem(string nomeProduto, string codigoProduto, double valorItemPedido, bool brinde = false)
        {
            ValidarItem(nomeProduto, codigoProduto, valorItemPedido);

            if (IsValid)
            {
                NomeProduto = nomeProduto;
                CodigoProduto = codigoProduto;
                ValorItemPedido = valorItemPedido;
                Brinde = brinde;
            }
        }
        private void ValidarItem(string nomeProduto, string codigoProduto, double valorItemPedido)
        {
            if (string.IsNullOrEmpty(nomeProduto))
                AddError("Nome do produto é obrigatório");

            if (string.IsNullOrEmpty(codigoProduto))
                AddError("Código produto é obrigatório");

            if (valorItemPedido < 0 || valorItemPedido > int.MaxValue)
                AddError("Valor do produto inválido");
        }
        public string NomeProduto { get; private set; }
        public string CodigoProduto { get; private set; }
        public double ValorItemPedido { get; private set; }
        public bool Brinde { get; private set; }
    }
}

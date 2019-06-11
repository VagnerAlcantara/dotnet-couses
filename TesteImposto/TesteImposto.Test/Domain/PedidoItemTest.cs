using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TesteImposto.Domain;

namespace TesteImposto.Test.Domain
{
    [TestClass]
    public class PedidoItemTest
    {
        #region| Teste para criação de itens de pedido inválido
        private static IEnumerable<object[]> PedidoItemsInvalidosList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{"", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false},
                        new object[]{"", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true},
                        new object[]{"", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false},
                        new object[]{"", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true},
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(PedidoItemsInvalidosList))]
        [TestCategory("Pedido Item")]
        public void CreateInvalidPedido(string nomeProduto, string codigoProduto, double valorItemPedido, bool brinde = false)
        {
            PedidoItem pedidoItem = new PedidoItem(nomeProduto, codigoProduto, valorItemPedido, brinde);

            Assert.IsFalse(pedidoItem.IsValid);
        }
        #endregion

        #region| Teste para criação de itens de pedido válido
        private static IEnumerable<object[]> PedidoItemsValidosList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{"Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true},
                        new object[]{"Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false},
                        new object[]{"Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true},
                        new object[]{"Produto D", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false},
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(PedidoItemsValidosList))]
        [TestCategory("Pedido Item")]
        public void CreateValidPedido(string nomeProduto, string codigoProduto, double valorItemPedido, bool brinde = false)
        {
            PedidoItem pedidoItem = new PedidoItem(nomeProduto, codigoProduto, valorItemPedido, brinde);

            Assert.IsTrue(pedidoItem.IsValid);
        }
        #endregion
    }
}

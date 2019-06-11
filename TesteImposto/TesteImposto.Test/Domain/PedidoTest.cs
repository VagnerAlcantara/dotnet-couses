using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteImposto.Domain;

namespace TesteImposto.Test.Domain
{
    [TestClass]
    public class PedidoTest
    {
        #region| Teste para criação de pedidos inválido
        private static IEnumerable<object[]> PedidosInvalidosList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{"", "SP", "Cliente"},
                        new object[]{"SP","", "Cliente"},
                        new object[]{"SP", "RJ", ""},
                        new object[]{"","",""}
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(PedidosInvalidosList))]
        [TestCategory("Pedido")]
        public void CreateInvalidPedido(string estadoDestino, string estadoOrigem, string nomeCliente)
        {
            Pedido pedido = new Pedido(estadoDestino, estadoOrigem, nomeCliente);

            Assert.IsFalse(pedido.IsValid);
        }
        #endregion

        #region| Teste para criação de pedidos Válido
        private static IEnumerable<object[]> PedidosValidosList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{"RJ", "SP", "Cliente"},
                        new object[]{"SP","MG", "Cliente"},
                        new object[]{"SP", "RJ", "Cliente"},
                        new object[]{"SP","SP","Cliente"}
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(PedidosValidosList))]
        [TestCategory("Pedido")]
        public void CreateValidPedido(string estadoDestino, string estadoOrigem, string nomeCliente)
        {
            Pedido pedido = new Pedido(estadoDestino, estadoOrigem, nomeCliente);

            Assert.IsTrue(pedido.IsValid);
        }
        #endregion
    }
}

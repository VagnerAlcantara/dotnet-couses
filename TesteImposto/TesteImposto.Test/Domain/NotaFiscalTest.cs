using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TesteImposto.Domain;

namespace TesteImposto.Test.Domain
{
    [TestClass]
    public class NotaFiscalTest
    {
        List<PedidoItem> _itens = new List<PedidoItem>
        {
            new PedidoItem( "Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true ),
            new PedidoItem( "Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false ),
            new PedidoItem( "Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true ),
            new PedidoItem( "Produto D", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false ),
        };

        #region| Teste para emissão de uma nota fiscal inválida
        private static IEnumerable<object[]> NotaFiscalInvalidosList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{"", "SP", "RJ"},
                        new object[]{"Cliente A","", "RJ"},
                        new object[]{"Cliente A", "SP", ""},
                        new object[]{"","",""}
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NotaFiscalInvalidosList))]
        [TestCategory("Nota Fiscal")]
        public void CreateInvalidNotaFiscal(string nomeCliente, string estadoOrigem, string estadoDestino)
        {
            NotaFiscal notaFiscal = new NotaFiscal(nomeCliente, estadoOrigem, estadoDestino, _itens);

            Assert.IsFalse(notaFiscal.IsValid);
        }
        #endregion

        #region| Teste para emissão de uma nota fiscal válida
        private static IEnumerable<object[]> NotaFiscalValidosList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{"Cliente A", "SP", "RJ"},
                        new object[]{"Cliente B","MG", "RJ"},
                        new object[]{"Cliente C", "SP", "MG"},
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(NotaFiscalValidosList))]
        [TestCategory("Nota Fiscal")]
        public void CreateValidNotaFiscal(string nomeCliente, string estadoOrigem, string estadoDestino)
        {
            NotaFiscal notaFiscal = new NotaFiscal(nomeCliente, estadoOrigem, estadoDestino, _itens);

            Assert.IsTrue(notaFiscal.IsValid);
        }
        #endregion

    }
}

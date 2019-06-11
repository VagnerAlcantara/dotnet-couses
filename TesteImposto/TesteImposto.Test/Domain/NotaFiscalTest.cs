using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TesteImposto.Domain;

namespace TesteImposto.Test.Domain
{
    [TestClass]
    public class NotaFiscalTest
    {
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
            NotaFiscal notaFiscal = new NotaFiscal(nomeCliente, estadoOrigem, estadoDestino);

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
            NotaFiscal notaFiscal = new NotaFiscal(nomeCliente, estadoOrigem, estadoDestino);

            Assert.IsTrue(notaFiscal.IsValid);
        }
        #endregion

    }
}

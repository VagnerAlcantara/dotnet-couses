using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TesteImposto.Domain;

namespace TesteImposto.Test.Domain
{
    [TestClass]
    public class NotaFiscalItemTest
    {
        #region| Teste para criação de um item inválido para nota fiscal
        private static IEnumerable<object[]> ItemNotaFiscalInvalidaList
        {
            get
            {
                return new List<object[]>
                    {
                        //sem cfop
                        new object[]{ new Random().Next(0, int.MaxValue), "", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), false},
                        //sem tipoIcms
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), true},
                        //sem baseIcms
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", null, Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), false},
                        //sem aliquotaIcms
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), null, Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), true},
                        //sem valorIcms
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), null, "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), false},
                        //sem nome produto
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), true},
                        //sem código produto
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), null, "Produto A", "", Math.Round(new Random().NextDouble(), 4), false},
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ItemNotaFiscalInvalidaList))]
        [TestCategory("Item da nota fiscal")]
        public void CreateInvalidNotaFiscal(int idNotaFiscal, string cfop, string tipoIcms, double? baseIcms, double? aliquotaIcms, double? valorIcms, string nomeProduto, string codigoProduto, double valorProduto, bool brinde)
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem(idNotaFiscal, cfop, tipoIcms, baseIcms, aliquotaIcms, valorIcms, nomeProduto, codigoProduto, valorProduto, brinde);

            Assert.IsFalse(notaFiscalItem.IsValid);
        }
        #endregion

        #region| Teste para criação de um item válido para nota fiscal
        private static IEnumerable<object[]> ItemNotaFiscalValidaList
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), true},
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), false},
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), true},
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), false},
                        new object[]{ new Random().Next(0, int.MaxValue), "6.000", "60", Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), Math.Round(new Random().NextDouble(), 4), "Produto A", new Random().Next(0, int.MaxValue).ToString(), Math.Round(new Random().NextDouble(), 4), true},
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ItemNotaFiscalValidaList))]
        [TestCategory("Nota Fiscal")]
        public void CreateValidNotaFiscal(int idNotaFiscal, string cfop, string tipoIcms, double? baseIcms, double? aliquotaIcms, double? valorIcms, string nomeProduto, string codigoProduto, double valorProduto, bool brinde)
        {
            NotaFiscalItem notaFiscalItem = new NotaFiscalItem(idNotaFiscal, cfop, tipoIcms, baseIcms, aliquotaIcms, valorIcms, nomeProduto, codigoProduto, valorProduto, brinde);

            Assert.IsTrue(notaFiscalItem.IsValid);
        }
        #endregion

    }
}

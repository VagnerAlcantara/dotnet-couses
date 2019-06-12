using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteImposto.Data;
using TesteImposto.Domain;

namespace TesteImposto.Test.Data
{
    [TestClass]
    public class NotaFiscalTest
    {
        [TestMethod]
        [TestCategory("Nota Fiscal repository")]
        public void GerarNotaFiscalTest()
        {
            //arrange
            Pedido pedido = new Pedido("SP", "RO", "Cliente A");
            pedido.AddItem(new PedidoItem("Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true));
            pedido.AddItem(new PedidoItem("Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));
            pedido.AddItem(new PedidoItem("Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));

            if (pedido.IsValid)
            {
                NotaFiscal notaFiscal = new NotaFiscal(pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem);

                notaFiscal.EmitirNotaFiscal(pedido);

                if (notaFiscal.IsValid)
                {
                    //act
                    NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
                    notaFiscalRepository.GravarNotaFiscal(notaFiscal);
                    Assert.IsTrue(notaFiscalRepository.IsValid);

                }
            }

        }
    }
}

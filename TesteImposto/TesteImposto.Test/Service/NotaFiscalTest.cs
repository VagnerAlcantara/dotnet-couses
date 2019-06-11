using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteImposto.Domain;
using TesteImposto.Service;

namespace TesteImposto.Test.Service
{
    [TestClass]
    public class NotaFiscalTest
    {
        [TestMethod]
        [TestCategory("Nota fiscal service")]
        public void GerarNotaFiscalSemEstadoOrigemTest()
        {
            //arrange
            Pedido pedido = new Pedido("", "RJ", "Cliente A");
            pedido.AddItem(new PedidoItem("Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true));
            pedido.AddItem(new PedidoItem("Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));
            pedido.AddItem(new PedidoItem("Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));

            //act
            NotaFiscalService notaFiscalService = new NotaFiscalService();
            notaFiscalService.GerarNotaFiscal(pedido);

            //assert
            Assert.IsFalse(notaFiscalService.IsValid);
        }

        [TestMethod]
        [TestCategory("Nota fiscal service")]
        public void GerarNotaFiscalSemEstadoDestinoTest()
        {
            //arrange
            Pedido pedido = new Pedido("SP", "", "Cliente A");
            pedido.AddItem(new PedidoItem("Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true));
            pedido.AddItem(new PedidoItem("Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));
            pedido.AddItem(new PedidoItem("Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));

            //act
            NotaFiscalService notaFiscalService = new NotaFiscalService();
            notaFiscalService.GerarNotaFiscal(pedido);

            //assert
            Assert.IsFalse(notaFiscalService.IsValid);
        }

        [TestMethod]
        [TestCategory("Nota fiscal service")]
        public void GerarNotaFiscalComItemInvalidoTest()
        {
            //arrange
            Pedido pedido = new Pedido("SP", "RJ", "Cliente A");
            pedido.AddItem(new PedidoItem("Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true));
            pedido.AddItem(new PedidoItem("", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));
            pedido.AddItem(new PedidoItem("Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));

            //act
            NotaFiscalService notaFiscalService = new NotaFiscalService();

            notaFiscalService.GerarNotaFiscal(pedido);

            //assert
            Assert.IsFalse(notaFiscalService.IsValid);
        }

        [TestMethod]
        [TestCategory("Nota fiscal service")]
        public void GerarNotaFiscalValidaTest()
        {
            //arrange
            Pedido pedido = new Pedido("SP", "RJ", "Cliente A");
            pedido.AddItem(new PedidoItem("Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true));
            pedido.AddItem(new PedidoItem("Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));
            pedido.AddItem(new PedidoItem("Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));

            //act
            NotaFiscalService notaFiscalService  = new NotaFiscalService();
            notaFiscalService.GerarNotaFiscal(pedido);

            //assert
            Assert.IsTrue(notaFiscalService.IsValid);
        }
    }
}

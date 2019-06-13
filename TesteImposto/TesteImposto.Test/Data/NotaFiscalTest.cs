using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteImposto.Data;
using TesteImposto.Domain;

namespace TesteImposto.Test.Data
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

        [TestMethod]
        [TestCategory("Nota Fiscal repository")]
        public void GerarNotaFiscalTest()
        {
            NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();

            //arrange
            Pedido pedido = new Pedido("SP", "RO", "Cliente A", _itens);
            pedido.AddItem(new PedidoItem("Produto A", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), true));
            pedido.AddItem(new PedidoItem("Produto B", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));
            pedido.AddItem(new PedidoItem("Produto C", Guid.NewGuid().ToString().Substring(0, 10), Math.Round(new Random().NextDouble(), 4), false));

            if (pedido.IsValid)
            {
                NotaFiscal notaFiscal = new NotaFiscal(pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem, _itens);

                if (notaFiscal.IsValid)
                {
                    //act
                    notaFiscalRepository.GravarNotaFiscal(notaFiscal);
                }
            }

            Assert.IsTrue(notaFiscalRepository.IsValid);
        }
    }
}

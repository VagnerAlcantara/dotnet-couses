using TesteImposto.Domain;
using TesteImposto.Shared;

namespace TesteImposto.Service
{
    public class NotaFiscalService : Notification
    {
        public void GerarNotaFiscal(Pedido pedido)
        {
            if (!pedido.IsValid)
                AddError(pedido.Errors);

            NotaFiscal notaFiscal = new NotaFiscal(pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem);

            if (!notaFiscal.IsValid)
                AddError(notaFiscal.Errors);

            if(IsValid)
                notaFiscal.EmitirNotaFiscal(pedido);
        }
    }
}

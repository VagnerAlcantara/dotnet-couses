using TesteImposto.Data;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Services;
using TesteImposto.Shared;

namespace TesteImposto.Service
{
    public class NotaFiscalService : Notification, INotaFiscalService
    {
        private readonly NotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService()
        {
            _notaFiscalRepository = new NotaFiscalRepository();
        }
        /// <summary>
        /// Gera nota fiscal com base num pedido
        /// </summary>
        /// <param name="pedido">Dados do pedido para geração da nota fiscal</param>
        public void GerarNotaFiscal(Pedido pedido)
        {
            if (!pedido.IsValid)
            {
                AddError(pedido.Errors);
                return;
            }

            NotaFiscal notaFiscal = new NotaFiscal(pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem, pedido.ItensDoPedido);

            if (!notaFiscal.IsValid)
            {
                AddError(notaFiscal.Errors);
                return;
            }

            _notaFiscalRepository.GravarNotaFiscal(notaFiscal);

            if (!_notaFiscalRepository.IsValid)
                AddError(_notaFiscalRepository.Errors);
        }
    }
}

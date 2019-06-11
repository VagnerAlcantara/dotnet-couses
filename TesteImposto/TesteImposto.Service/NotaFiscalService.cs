using System;
using TesteImposto.Data;
using TesteImposto.Domain;
using TesteImposto.Domain.Interfaces.Repositories;
using TesteImposto.Domain.Interfaces.Services;
using TesteImposto.Shared;
using TesteImposto.Shared.Xml;

namespace TesteImposto.Service
{
    public class NotaFiscalService : Notification, INotaFiscalService
    {
        private readonly NotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService()
        {
            _notaFiscalRepository = new NotaFiscalRepository();
        }
        /*
        private readonly INotaFiscalRepository _notaFiscalRepository;
        
        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }
        */
        public void GerarNotaFiscal(Pedido pedido)
        {
            if (!pedido.IsValid)
            {
                AddError(pedido.Errors);
                return;
            }

            NotaFiscal notaFiscal = new NotaFiscal(pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem);

            if (!notaFiscal.IsValid)
            {
                AddError(notaFiscal.Errors);
                return;
            }

            notaFiscal = notaFiscal.EmitirNotaFiscal(pedido);

            if (!notaFiscal.IsValid)
            {
                AddError(notaFiscal.Errors);
                return;
            }
            try
            {
                XmlShared.CreateXmlFile<NotaFiscal>(notaFiscal);
            }
            catch (Exception)
            {
                AddError("Erro ao gerar XML");
            }

            _notaFiscalRepository.GerarNotaFiscal(notaFiscal);
        }
    }
}

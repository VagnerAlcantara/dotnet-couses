using System;
using TesteImposto.Domain.Interfaces.Shared;

namespace TesteImposto.Domain.Interfaces.Services
{
    public interface INotaFiscalService : INotification
    {
        void GerarNotaFiscal(Pedido pedido);
    }
}

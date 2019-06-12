using System.Collections.Generic;

namespace TesteImposto.Domain.Interfaces.Repositories
{
    public interface INotaFiscalItemRepository 
    {
        void GravarItemNotaFiscal(IEnumerable<NotaFiscalItem> entities, int idNotaFiscal);
    }
}

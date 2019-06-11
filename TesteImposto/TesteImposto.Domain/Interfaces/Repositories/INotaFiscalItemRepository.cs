using System.Collections.Generic;

namespace TesteImposto.Domain.Interfaces.Repositories
{
    public interface INotaFiscalItemRepository 
    {
        void Add(IEnumerable<NotaFiscalItem> entities, int idNotaFiscal);
    }
}

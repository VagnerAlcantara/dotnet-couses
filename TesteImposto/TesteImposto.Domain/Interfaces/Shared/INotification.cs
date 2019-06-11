using System.Collections.Generic;

namespace TesteImposto.Domain.Interfaces.Shared
{
    public interface INotification
    {
        void AddError(string erro);
        void AddError(IList<string> erros);
    }
}

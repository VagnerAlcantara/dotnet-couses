using Locadora.Domain.Entities;
using System.Collections.Generic;

namespace Locadora.Domain.Interface.BLL
{
    public interface ILocacaoBusiness : IBusinessBase<Locacao>
    {
        List<Locacao> ObterPorCliente(int idCliente);
    }
}

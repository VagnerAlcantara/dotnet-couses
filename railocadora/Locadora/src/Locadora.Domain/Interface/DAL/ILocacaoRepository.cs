using Locadora.Domain.Entities;
using System.Collections.Generic;

namespace Locadora.Domain.Interface.DAL
{
    public interface ILocacaoRepository : IRepositoryBase<Locacao>
    {
        List<Locacao> ObterPorCliente(int idCliente);
    }
}

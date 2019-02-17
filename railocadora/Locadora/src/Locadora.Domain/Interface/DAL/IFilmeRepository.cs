using Locadora.Domain.Entities;
using System.Collections.Generic;

namespace Locadora.Domain.Interface.DAL
{
    public interface IFilmeRepository : IRepositoryBase<Filme>
    {
        IList<Filme> Obter(string titulo);
        IList<Filme> Obter();
    }
}

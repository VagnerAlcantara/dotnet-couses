using Locadora.Domain.Entities;
using System.Collections.Generic;

namespace Locadora.Domain.Interface.BLL
{
    public interface IFilmeBusiness : IBusinessBase<Filme>
    {
        IList<Filme> Obter(string titulo);
        IList<Filme> Obter();
    }
}

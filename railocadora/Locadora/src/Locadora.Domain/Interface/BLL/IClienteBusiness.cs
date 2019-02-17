using Locadora.Domain.Entities;
using Locadora.Domain.Interface.DAL;

namespace Locadora.Domain.Interface.BLL
{
    public interface IClienteBusiness : IRepositoryBase<Cliente>
    {
        void Inativar(int id);
        Cliente Obter(string cpf);
    }
}

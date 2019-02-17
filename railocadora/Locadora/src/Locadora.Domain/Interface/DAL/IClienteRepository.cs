using Locadora.Domain.Entities;

namespace Locadora.Domain.Interface.DAL
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        void Inativar(int id);
        Cliente Obter(string cpf);
    }
}

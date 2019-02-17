using Locadora.Data;
using Locadora.Domain.Entities;
using Locadora.Domain.Interface.BLL;

namespace Locadora.BLL
{
    public class ClienteBusiness : IClienteBusiness
    {
        private ClienteRepository _clienteRepository;

        public ClienteBusiness()
        {
            _clienteRepository = new ClienteRepository();
        }

        public void Adicionar(Cliente entity)
        {
            _clienteRepository.Adicionar(entity);
        }

        public void Alterar(Cliente entity)
        {
            _clienteRepository.Alterar(entity);
        }

        public void Excluir(int id)
        {
            _clienteRepository.Excluir(id);
        }

        public void Inativar(int id)
        {
            _clienteRepository.Inativar(id);
        }

        public Cliente Obter(int id)
        {
            return _clienteRepository.Obter(id);
        }

        public Cliente Obter(string cpf)
        {
            return _clienteRepository.Obter(cpf);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        
    }
}

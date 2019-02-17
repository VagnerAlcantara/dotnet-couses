using System;

namespace Locadora.Domain.Interface.BLL
{
    public interface IBusinessBase<T> : IDisposable where T : class
    {
        void Adicionar(T entity);
        void Alterar(T entity);
        void Excluir(int id);
        T Obter(int id);
    }
}

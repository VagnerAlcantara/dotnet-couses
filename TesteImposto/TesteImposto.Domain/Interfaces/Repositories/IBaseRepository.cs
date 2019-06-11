using System;
using System.Collections.Generic;

namespace TesteImposto.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        void Add(T entity);
        //void Alterar(T entity);
        //void Excluir(int id);
        //T Obter(int id);
        //IEnumerable<T> Get();
    }
}

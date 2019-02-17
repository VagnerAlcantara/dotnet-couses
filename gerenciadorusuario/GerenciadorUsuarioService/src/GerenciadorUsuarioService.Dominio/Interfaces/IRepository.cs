using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GerenciadorUsuarioService.Dominio.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        T Adicionar(T entidade);
        T ObterPorId(int id);
        IEnumerable<T> ObterTodos();
        T Atualizar(T entidade);
        void Remover(int id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
        int SaveChanges();

    }
}

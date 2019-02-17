using EF.Domain.Interface.Repository;
using System;
using System.Data.Entity;

namespace EF.Infra.Data.Repositories
{
    public abstract class Repository<T> : _IRepository<T>, IDisposable where T : class
    {
        private DataContext.DataContext _context;
        private DbSet _db;

        public Repository()
        {
            _context = new DataContext.DataContext();
            _db = _context.Set<T>();
        }

        public void Adicionar(T entity)
        {
            try
            {
                _db.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(T entity)
        {
            try
            {
                var result = _db.Find(entity);

                if (result == null)
                    throw new Exception("Registro não encontrado");

                _db.Attach(entity);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var result = _db.Find(id);

                if (result == null)
                    throw new Exception("Registro não encontrado");

                _db.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Obter(int id)
        {
            try
            {
                using (var db = new DataContext.DataContext())
                {
                    var result = db.Set<T>().Find(id);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}

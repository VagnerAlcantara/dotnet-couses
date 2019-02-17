namespace EF.Domain.Interface.Repository
{
    public interface _IRepository<T> where T : class 
    {
        void Adicionar(T entity);
        void Alterar(T entity);
        void Excluir(int id);
        T Obter(int id);
    }
}

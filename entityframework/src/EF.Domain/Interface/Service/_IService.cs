namespace EF.Domain.Interface.Service
{
    public interface _IService<T> where T : class
    {
        void Adicionar(T entity);
        void Alterar(T entity);
        void Excluir(int id);
        T Obter(int id);
    }
}

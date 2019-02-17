namespace YouLearn.Domain.Interfaces.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}

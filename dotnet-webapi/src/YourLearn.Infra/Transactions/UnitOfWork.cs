using YouLearn.Domain.Interfaces.Transactions;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YouLearnContext _youLearnContext;

        public UnitOfWork(YouLearnContext youLearnContext)
        {
            _youLearnContext = youLearnContext;
        }

        public void Commit()
        {
            _youLearnContext.SaveChanges();
        }
    }
}

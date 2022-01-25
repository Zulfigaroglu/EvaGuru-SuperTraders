using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;

namespace SuperTraders.Data.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
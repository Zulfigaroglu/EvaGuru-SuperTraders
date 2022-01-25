using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;

namespace SuperTraders.Data.Repositories
{
    public class BuyOrderRepository : BaseRepository<BuyOrder>, IBuyOrderRepository
    {
        public BuyOrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
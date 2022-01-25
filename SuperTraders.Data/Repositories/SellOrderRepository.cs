using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;

namespace SuperTraders.Data.Repositories
{
    public class SellOrderRepository : BaseRepository<SellOrder>, ISellOrderRepository
    {
        public SellOrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
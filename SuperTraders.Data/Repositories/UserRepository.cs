using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;

namespace SuperTraders.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
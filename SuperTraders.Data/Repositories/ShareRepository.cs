using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;

namespace SuperTraders.Data.Repositories
{
    public class ShareRepository : BaseRepository<Share>, IShareRepository
    {
        public ShareRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
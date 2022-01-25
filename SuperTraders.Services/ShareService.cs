using System.Collections.Generic;
using System.Threading.Tasks;
using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Services
{
    public class ShareService: IShareService
    {
        private readonly IShareRepository _shareRepository;

        public ShareService(IShareRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }

        public async Task<ICollection<Share>> All()
        {
            ICollection<Share> shares = await _shareRepository.All();
            return shares;
        }
    }
}
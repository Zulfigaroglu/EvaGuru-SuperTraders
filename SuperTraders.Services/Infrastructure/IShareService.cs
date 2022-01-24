using System.Collections.Generic;
using System.Threading.Tasks;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;

namespace SuperTraders.Services.Infrastructure
{
    public interface IShareService
    {
        Task<ICollection<Share>> All();
    }
}
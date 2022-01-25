using System.Threading.Tasks;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;

namespace SuperTraders.Services.Infrastructure
{
    public interface IOrderService
    {
        Task<BuyOrder> Buy(User user, OrderDto orderDto);
        Task<SellOrder> Sell(User user, OrderDto orderDto);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;
using SuperTraders.Core.Mapper;
using SuperTraders.Data.Repositories.Infrastructure;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Services
{
    public class OrderService : IOrderService
    {
        private readonly ISellOrderRepository _sellOrderRepositoryRepository;
        private readonly IBuyOrderRepository _buyOrderRepositoryRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public OrderService(
            ISellOrderRepository sellOrderRepositoryRepository,
            IBuyOrderRepository buyOrderRepositoryRepository,
            ITransactionRepository transactionRepository,
            IMapper mapper
        )
        {
            _sellOrderRepositoryRepository = sellOrderRepositoryRepository;
            _buyOrderRepositoryRepository = buyOrderRepositoryRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<BuyOrder> Buy(User user, OrderDto orderDto)
        {
            BuyOrder buyOrder = _mapper.Map<BuyOrder>(orderDto);
            buyOrder.UserId = user.Id;
            buyOrder.RemainingAmount = buyOrder.Amount;
            buyOrder = await _buyOrderRepositoryRepository.Create(buyOrder);
            PerformTransactions();
            return buyOrder;
        }

        public async Task<SellOrder> Sell(User user, OrderDto orderDto)
        {
            SellOrder sellOrder = _mapper.Map<SellOrder>(orderDto);
            sellOrder.UserId = user.Id;
            sellOrder.RemainingAmount = sellOrder.Amount;
            sellOrder = await _sellOrderRepositoryRepository.Create(sellOrder);
            PerformTransactions();
            return sellOrder;
        }

        private async void PerformTransactions()
        {
            List<BuyOrder> buyOrders = await _buyOrderRepositoryRepository.All();
            List<SellOrder> sellOrders = await _sellOrderRepositoryRepository.All();

            foreach (BuyOrder buyOrder in buyOrders)
            {
                List<SellOrder> sellOrdersToMakeTransaction = sellOrders
                    .Where(so => so.UnitPrice < buyOrder.UnitPrice)
                    .OrderBy(so => so.UnitPrice).ToList();

                if (sellOrdersToMakeTransaction.Count > 0)
                {
                    foreach (SellOrder sellOrder in sellOrdersToMakeTransaction)
                    {
                        float amount = buyOrder.Amount < sellOrder.Amount ? buyOrder.Amount : sellOrder.Amount;
                        _transactionRepository.Create(new Transaction()
                        {
                            BuyOrderId = buyOrder.Id,
                            SellOrderId = sellOrder.Id,
                            Amount = amount,
                        });
                    }
                }
            }
        }
    }
}
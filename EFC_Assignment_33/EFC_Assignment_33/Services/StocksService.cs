using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using System;

namespace Services
{
    public class StocksService : IStocksService
    {
        private readonly List<BuyOrder> _buyOrders;
        private readonly List<SellOrder> _sellOrders;
        private readonly StockMarketDbContext _dbContext;

        public StocksService(StockMarketDbContext dbContext)
        {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
            _dbContext = dbContext;
        }


        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if (buyOrderRequest == null)
                throw new ArgumentNullException(nameof(buyOrderRequest));

            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderID = Guid.NewGuid();

            //_buyOrders.Add(buyOrder);
            _dbContext.Add(buyOrder);
            await _dbContext.SaveChangesAsync();

            return buyOrder.ToBuyOrderResponse();
        }

        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest == null)
                throw new ArgumentNullException(nameof(sellOrderRequest));

            ValidationHelper.ModelValidation(sellOrderRequest);

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            sellOrder.SellOrderID = Guid.NewGuid();

            //_sellOrders.Add(sellOrder);
            _dbContext.Add(sellOrder);
            await _dbContext.SaveChangesAsync();

            return sellOrder.ToSellOrderResponse();
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            //return  _buyOrders.OrderByDescending(temp =>  temp.DateAndTimeOfOrder).Select(temp => temp.ToBuyOrderResponse()).ToList();
            return await _dbContext.BuyOrders.Select(buyOrders => buyOrders.ToBuyOrderResponse()).ToListAsync();

        }

        public async Task<List<SellOrderResponse>> GetSellOrders()
        {
            //return _sellOrders.OrderByDescending(temp => temp.DateAndTimeOfOrder).Select(temp => temp.ToSellOrderResponse()).ToList();
            return await _dbContext.SellOrders.Select(sellOrders => sellOrders.ToSellOrderResponse()).ToListAsync();
        }
    }
}
 
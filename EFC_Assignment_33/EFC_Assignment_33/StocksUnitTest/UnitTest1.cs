using ServiceContracts;
using Services;
using Entities;
using ServiceContracts.DTO;
using Microsoft.EntityFrameworkCore;

namespace StocksUnitTest
{
    public class UnitTest1
    {

        private readonly IStocksService _stocksService;

        public UnitTest1()
        {
            _stocksService = new StocksService(new StockMarketDbContext(new DbContextOptionsBuilder<StockMarketDbContext>().Options));
        }

        #region CreateBuyOrder
        [Fact]
        public void CreateBuyOrder_NullBuyOrder()
        {
            BuyOrderRequest? buyOrderRequest = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_QuantityLessThanMinimum()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10,
                Quantity = 0
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_QuantityMoreThanMaximum()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10,
                Quantity = 100001
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_PriceLessThanMinimum()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 0,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_PriceMoreThanMaximum()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10001,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_NullStockSymbol()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = null,
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidDateAndTimeOfOrder()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"),
                Price = 10,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public async void CreateBuyOrder_ValidParameters()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("2020-12-31"),
                Price = 10,
                Quantity = 10
            };

            BuyOrderResponse buyOrderResponseFromCreate = await _stocksService.CreateBuyOrder(buyOrderRequest);
            Assert.NotEqual(Guid.Empty, buyOrderResponseFromCreate.BuyOrderID);
        }

        #endregion CreateBuyOrder

        #region CreateSellOrder
        [Fact]
        public void CreateSellOrder_NullBuyOrder()
        {
            SellOrderRequest? sellOrderRequest = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_QuantityLessThanMinimum()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10,
                Quantity = 0
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_QuantityMoreThanMaximum()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10,
                Quantity = 100001
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_PriceLessThanMinimum()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 0,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_PriceMoreThanMaximum()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10001,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_NullStockSymbol()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = null,
                StockName = "Microsoft",
                DateAndTimeOfOrder = new DateTime(),
                Price = 10,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_InvalidDateAndTimeOfOrder()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"),
                Price = 10,
                Quantity = 10
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public async void CreateSellOrder_ValidParameters()
        {
            SellOrderRequest sellOrderRequest = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("2020-12-31"),
                Price = 10,
                Quantity = 10
            };

            SellOrderResponse sellOrderResponseFromCreate = await _stocksService.CreateSellOrder(sellOrderRequest);
            Assert.NotEqual(Guid.Empty, sellOrderResponseFromCreate.SellOrderID);
        }


        #endregion CreateSellOrder

        #region GetAllBuyOrders
        [Fact]
        public async void GetAllBuyOrders_EmptyList()
        {

            List<BuyOrderResponse> buyOrdersList = await _stocksService.GetBuyOrders();
            Assert.Empty(buyOrdersList);
        }

        [Fact]
        public async void GetAllBuyOrders_WithBuyOrder()
        {
            BuyOrderRequest buyOrderRequest1 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("2020-12-31"),
                Price = 10,
                Quantity = 10
            };

            BuyOrderRequest buyOrderRequest2 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("2021-12-31"),
                Price = 100,
                Quantity = 100
            };

            List<BuyOrderRequest> listBuyOrderRequest = new List<BuyOrderRequest>() { buyOrderRequest1, buyOrderRequest2 };
            List<BuyOrderResponse> listBuyOrderResponseFromAdd = new List<BuyOrderResponse>();

            foreach(BuyOrderRequest buyOrderRequest in listBuyOrderRequest)
            {
                BuyOrderResponse buyOrderResponseFromCreate = await _stocksService.CreateBuyOrder(buyOrderRequest);
                listBuyOrderResponseFromAdd.Add(buyOrderResponseFromCreate);
            }
            
            List<BuyOrderResponse> buyOrdersList = await _stocksService.GetBuyOrders();
            foreach(BuyOrderResponse buyOrderResponseFromAdd in listBuyOrderResponseFromAdd)
            {
                Assert.Contains(buyOrderResponseFromAdd, buyOrdersList);
            }
        }

        #endregion GetAllBuyOrders

        #region GetAllSellOrder
        [Fact]
        public async void GetAllSellOrder_EmptyList()
        {

            List<SellOrderResponse> sellOrderList = await _stocksService.GetSellOrders();
            Assert.Empty(sellOrderList);
        }

        [Fact]
        public async void GetAllSellOrder_WithBuyOrder()
        {
            SellOrderRequest sellOrderRequest1 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("2020-12-31"),
                Price = 10,
                Quantity = 10
            };

            SellOrderRequest sellOrderRequest2 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                DateAndTimeOfOrder = Convert.ToDateTime("2021-12-31"),
                Price = 100,
                Quantity = 100
            };

            List<SellOrderRequest> listSellOrderRequest = new List<SellOrderRequest>() { sellOrderRequest1, sellOrderRequest2 };
            List<SellOrderResponse> listSellOrderResponseFromAdd = new List<SellOrderResponse>();

            foreach (SellOrderRequest sellOrderRequest in listSellOrderRequest)
            {
                SellOrderResponse sellOrderResponseFromCreate = await _stocksService.CreateSellOrder(sellOrderRequest);
                listSellOrderResponseFromAdd.Add(sellOrderResponseFromCreate);
            }

            List<SellOrderResponse> sellOrdersList = await _stocksService.GetSellOrders();
            foreach (SellOrderResponse sellOrderResponseFromAdd in listSellOrderResponseFromAdd)
            {
                Assert.Contains(sellOrderResponseFromAdd, sellOrdersList);
            }
        }
        #endregion GetAllSellOrder

    }
}
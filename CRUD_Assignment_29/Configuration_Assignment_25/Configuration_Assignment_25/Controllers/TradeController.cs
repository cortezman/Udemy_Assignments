using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Configuration_Assignment_25.Models;
using Services;
using ServiceContracts;
using ServiceContracts.DTO;
namespace Configuration_Assignment_25.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly FinnHubService _finnHubService;
        private readonly IConfiguration _configuration;
        private readonly IOptions<TradingOptions> _tradingOtions;
        private readonly IStocksService _stocksService;

        public TradeController(FinnHubService finnHubService, IConfiguration configuration, IOptions<TradingOptions> options, IStocksService stocksService)
        {
            _finnHubService = finnHubService;
            _tradingOtions = options;
            _configuration = configuration;
            _stocksService = stocksService;
        }

        [Route("/")]
        [Route("[action]")]
        [Route("~/[controller]")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOtions.Value.DefaultStockSymbol == null)
            {
                _tradingOtions.Value.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object>? stockPriceQoute = await _finnHubService.GetStockPriceQoute(_tradingOtions.Value.DefaultStockSymbol);
            Dictionary<string, object>? stockProfile = await _finnHubService.GetCompanyProfile(_tradingOtions.Value.DefaultStockSymbol);

            ViewBag.FinnHubToken = _configuration["FinnHubToken"];
            
            StockTrade stockTrade = new StockTrade() 
            { 
                StockSymbol = _tradingOtions.Value.DefaultStockSymbol,
                StockName = stockProfile["name"].ToString(),
                Price = Convert.ToDouble(stockPriceQoute["c"].ToString())
            };

            return View(stockTrade);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
        {
            buyOrderRequest.DateAndTimeOfOrder = DateTime.Now;

            ModelState.Clear();
            TryValidateModel(buyOrderRequest);

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade() 
                { 
                    StockName = buyOrderRequest.StockName, StockSymbol = buyOrderRequest.StockSymbol, Price = Convert.ToDouble(buyOrderRequest.Price), Quantity = buyOrderRequest.Quantity
                };
                return View("Index", stockTrade);
            }

            BuyOrderResponse buyOrderResponse = _stocksService.CreateBuyOrder(buyOrderRequest);

            return RedirectToAction(nameof(Orders));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
        {
            sellOrderRequest.DateAndTimeOfOrder = DateTime.Now;

            ModelState.Clear();
            TryValidateModel(sellOrderRequest);

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade()
                {
                    StockName = sellOrderRequest.StockName,
                    StockSymbol = sellOrderRequest.StockSymbol,
                    Price = Convert.ToDouble(sellOrderRequest.Price),
                    Quantity = sellOrderRequest.Quantity
                };
                return View("Index", stockTrade);
            }

            SellOrderResponse sellOrderResponse = _stocksService.CreateSellOrder(sellOrderRequest);

            return RedirectToAction(nameof(Orders));
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            List<BuyOrderResponse> listBuyOrderResponses = _stocksService.GetBuyOrders();
            List<SellOrderResponse> listSellOrderResponse = _stocksService.GetSellOrders();

            Orders orders = new Orders() 
            { 
                BuyOrders = listBuyOrderResponses, SellOrders = listSellOrderResponse
            };

            return View(orders);
        }

    }
}

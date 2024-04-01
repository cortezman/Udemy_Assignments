using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Configuration_Assignment_25.Models;
using Services;
namespace Configuration_Assignment_25.Controllers
{
    public class TradeController : Controller
    {
        private readonly FinnHubService _finnHubService;
        private readonly IConfiguration _configuration;
        private readonly IOptions<TradingOptions> _tradingOtions;

        public TradeController(FinnHubService finnHubService, IConfiguration configuration, IOptions<TradingOptions> options)
        {
            _finnHubService = finnHubService;
            _tradingOtions = options;
            _configuration = configuration;
        }

        [Route("/")]
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
    }
}

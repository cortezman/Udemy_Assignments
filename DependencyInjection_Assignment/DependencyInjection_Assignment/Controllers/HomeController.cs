using Models;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherservice;
        
        public HomeController(IWeatherService weatherService)
        {
            _weatherservice = weatherService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cityWeather = _weatherservice.GetWeatherDetails();
            return View(cityWeather);
        }

        [HttpGet]
        [Route("weather/{cityCode}")]
        public IActionResult CityWeather(string cityCode)
        {
            if (cityCode == null || !(cityCode != "LDN" || cityCode != "NYC" || cityCode != "PAR"))
            {
                return BadRequest("Invalid City Code");
            }

            CityWeather objCityWeather = _weatherservice.GetWeatherByCityCode(cityCode);

            return View(objCityWeather);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ViewComponentsAssignment.Models;

namespace ViewComponentsAssignment.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> cityWeather = new List<CityWeather>()
        {
            new CityWeather(){
                CityUniqueCode = "LDN",
                CityName = "London",
                DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
                TemperatureFahrenheit = 33
            },
            new CityWeather(){
                CityUniqueCode = "NYC",
                CityName = "New York",
                DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),
                TemperatureFahrenheit = 60
            },
            new CityWeather(){
                CityUniqueCode = "PAR",
            CityName = "Paris",
            DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
            TemperatureFahrenheit = 82
            }
        };

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
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
            CityWeather? objCityWeather = cityWeather.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();
            return View(objCityWeather);
        }
    }
}

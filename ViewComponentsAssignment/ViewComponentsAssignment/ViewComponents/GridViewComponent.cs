using Microsoft.AspNetCore.Mvc;
using ViewComponentsAssignment.Models;

namespace ViewComponentsAssignment.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather cityWeather)
        {
            return View(cityWeather);
        }
    }
}

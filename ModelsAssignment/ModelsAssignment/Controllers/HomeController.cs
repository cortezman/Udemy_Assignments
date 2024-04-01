using Microsoft.AspNetCore.Mvc;
using ModelsAssignment.Models;

namespace ModelsAssignment.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome");
        }

        [Route("/product")]
        [HttpPost]
        public IActionResult Orders(Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }

            Random random = new Random();
            order.OrderNo = random.Next(0,99999);
            var JsonData = new { OrderNumber = order.OrderNo };
            return Json(JsonData);
        }

    }
}

using Configuration_Assignment_24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configuration_Assignment_24.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialMediaLinksOptions _socialMediaLinksOptions;

        public HomeController(IOptions<SocialMediaLinksOptions> socialmedialinksOptions)
        {
            _socialMediaLinksOptions = socialmedialinksOptions.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.SocialMediaLinks = _socialMediaLinksOptions;
            return View();
        }
    }
}

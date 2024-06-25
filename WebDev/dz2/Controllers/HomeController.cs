using Microsoft.AspNetCore.Mvc;

namespace dz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/Contact")]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}

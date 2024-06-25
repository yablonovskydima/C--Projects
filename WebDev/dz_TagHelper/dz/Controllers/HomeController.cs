using Microsoft.AspNetCore.Mvc;


namespace dz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? countryId)
        {   
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;


namespace MVC3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public string Create(string name, int age) => $"Name: {name} \t Age: {age}";
    }
}
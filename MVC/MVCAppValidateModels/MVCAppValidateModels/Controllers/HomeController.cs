using Microsoft.AspNetCore.Mvc;
using MVCAppValidateModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVCAppValidateModels.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
        public IActionResult CreateClient() => View();

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email) 
        {
            if(email == "admin@gmail.com" || email == "dima@gmail.com") 
            {
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Person person) 
        {
            if (ModelState.IsValid)
                return Content($"{person.Name} - {person.Age}");
            return View();
        }

        [HttpPost]
        public string CreateClient(Person person) 
        {
            if (ModelState.IsValid)
                return $"{person.Name} - {person.Age}";
            return "Data is not valid";
        }
    }
}

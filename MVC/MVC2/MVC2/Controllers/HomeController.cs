using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using System.Diagnostics;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        //[Route("Home/Index")]
        //public string Index() => $"ASP NET Core";
        [Route("Home/About")]
        public IActionResult About() 
        {
            return Content("About site");
        }
      

        [HttpGet]
        public IActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public string Index(string username, string password, int age, string comment, string isVIP, string member) 
        {
            return $"User Name: {username}\tPassword: {password}\tAge: {age}\tComment: {comment}\tStatus: {isVIP}\tMember: {member}"; 
        } 




        public IActionResult Hello() 
        {
            return PartialView();
        }
    }
}
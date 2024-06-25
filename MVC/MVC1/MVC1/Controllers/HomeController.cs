using Microsoft.AspNetCore.Mvc;
using MVC1.Models;
using System.Diagnostics;

namespace MVC1.Controllers
{

    public class HomeController : Controller
    {
        public string IndexServ([FromServices] ITimeService timeService) 
        {
           return timeService.Time;
        }

        public string Index() 
        {
            ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            return timeService?.Time ?? "Undefined";
        }
        public IActionResult GetFile() 
        {
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            string file_type = "text/plain";
            string file_name = "download_hello.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }
        public IActionResult Index3() 
        {
            return RedirectToAction("About", "Home", new { name = "Tom", age = 18 });
        }
        public IActionResult About(string name, int age) 
        {
            return Content($"Name: {name}\tAge: {age}");
        }
        public IActionResult Contact() 
        {
            return Redirect("https://youtube.com");
        }

        //public IActionResult Index12() 
        //{
        //    return new HtmlResult("<h2>Hello asp.net</h2>");
        //}

    public JsonResult GetName() 
        {
            Person tom = new Person("Tom", 22);
            var jsonOption = new System.Text.Json.JsonSerializerOptions 
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };
            return Json(tom, jsonOption);
        }
        public async Task Test() 
        {
            Response.ContentType = "text/html; charset=utf-8";
            System.Text.StringBuilder tableBuilder = new System.Text.StringBuilder("<h2>Request headers</h2> <table>");
            foreach(var header in Request.Headers) 
            {
                tableBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td</tr>");
            }
            tableBuilder.Append("</table>");
            await Response.WriteAsync(tableBuilder.ToString());
        }
        [HttpGet]
        public async Task Index1() 
        {
            string content = @"<form method=""post"">
                                    <labe> Name </labe><br/>
                                    <input name = 'name'/><br/>
                                    <label> Age </label><br/>
                                    <input type = 'number' name = 'age'/><br/>
                                    <input type = 'submit' value = 'send'/>
                              </form>";
            Response.ContentType = "text/html; charset=utf-8";
            await Response.WriteAsync(content);
        }
        [HttpPost]
        public string Index(string[] names) 
        {
            string result = "";
            foreach(string name in names) 
            {
                result = $"{result} {name}";
            }
            return result;
        }
    }
    public record class Person(string Name, int Age);
}
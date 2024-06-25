using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public string Index(DayTimeViewModel model) => model.Period.ToString();
        public string Contacts() => "Contacts page";

        IEnumerable<Company> companies = new List<Company>
        {
            new Company(1,"Apple"),
            new Company(2, "Samsung"),
            new Company(3, "Google")
        };

        public IActionResult Create() 
        {
            ViewBag.Companies = new SelectList(companies, "Id", "Name");
            return View();
        }
        [HttpPost]
        public string Create(Product product) 
        {
            Company company = companies.FirstOrDefault(c => c.Id == product.CompanyId);
            return $"Add new item: {product.Name} ({company?.Name})";
        }
    }
    
}

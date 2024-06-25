using Microsoft.AspNetCore.Mvc;
using WebApplicationModels1.Models;
using WebApplicationModels1.ViewModels;

namespace WebApplicationModels1.Controllers
{
    public class HomeController : Controller
    {
        List<Person> people;
        List<Company> companies;
        List<Product> products;
        List<Country> countries;

        public HomeController() 
        {
            Company microsoft = new Company(1, "Microsoft", "USA");
            Company google = new Company(2, "Google", "USA");
            Company jetbrains = new Company(3, "JetBrains", "Czechia");

            companies = new List<Company> { microsoft, google, jetbrains };

            people = new List<Person>
            {
                new Person(1, "Tom", 37, microsoft),
                new Person(2, "Sam", 23, google),
                new Person(3, "Bob", 33, microsoft),
                new Person(4, "Josh", 23, microsoft),
                new Person(5, "Linda", 26, google),
                new Person(6, "Vitalik", 22, microsoft),
                new Person(7, "Peter", 45, jetbrains),
                new Person(8, "Dan", 19, jetbrains)
            };

            Country usa = new Country(1, "USA");
            Country germany = new Country(2, "Germany");
            Country china = new Country(3, "China");

            countries = new List<Country> { usa, germany, china };

            products = new List<Product>
            {
                new Product(1, "Lightbulb", germany),
                new Product(2, "Phone", usa),
                new Product(3, "Computer", usa),
                new Product(4, "Pencil", china),
                new Product(5, "Book", germany),
                new Product(6, "Charger", china),
            };
        }

        public IActionResult Index(int? countryId) 
        {
            List<CountryModel> models = countries.Select(c => new CountryModel(c.Id, c.Name)).ToList();
            models.Insert(0, new CountryModel(0, "All"));

            IndexViewModel viewModel = new() { Countries = models, Products = products };

            if(countryId is not null && countryId > 0) 
            {
                viewModel.Products = products.Where(p => p.Country.Id == countryId);
            }
            return View(viewModel);
        }
        public IActionResult Index1(int? companyId) 
        {
            List<CompanyModel> comModels = companies.Select(c => new CompanyModel(c.Id, c.Name)).ToList();
            comModels.Insert(0, new CompanyModel(0, "All"));

            IndexViewModel viewModel = new() { Companies = comModels, People = people };

            if(companyId is not null && companyId > 0) 
            {
                viewModel.People = people.Where(p => p.Company.Id == companyId);
            }

            return View(viewModel);
        }
    }
}

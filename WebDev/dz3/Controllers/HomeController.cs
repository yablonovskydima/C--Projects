using Microsoft.AspNetCore.Mvc;
using dz.Models;
using dz.ViewModels;

namespace dz.Controllers
{
    public class HomeController : Controller
    {
        List<Product> products;
        List<Country> countries;
        public HomeController() 
        {
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

            if (countryId is not null && countryId > 0)
            {
                viewModel.Products = products.Where(p => p.Country.Id == countryId);
            }
            return View(viewModel);
        }

        
    }
}

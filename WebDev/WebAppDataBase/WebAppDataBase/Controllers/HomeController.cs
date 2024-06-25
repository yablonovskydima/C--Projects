using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDataBase.Models;

namespace WebAppDataBase.Controllers
{
    public class HomeController : Controller
    {
        ProductsContext db;
        public HomeController(ProductsContext context)
        {
            db = context;
            if (!db.Producers.Any()) 
            {
                Producer apple = new Producer { Name = "        " };
                Producer samsung = new Producer { Name = "Samsung" };
                Producer google = new Producer { Name = "Google" };
                Producer oneplus = new Producer { Name = "OnePlus" };


                Product product1 = new Product { Name = "Samsung galax7 s21", Producer = samsung, Price = 1144 };
                Product product2 = new Product { Name = "Samsung galax7 s22", Producer = samsung, Price = 1218 };
                Product product3 = new Product { Name = "Google pixel 8", Producer = google, Price = 923 };
                Product product4 = new Product { Name = "Google pixel 9", Producer = google, Price = 1117 };
                Product product5 = new Product { Name = "One Plus 9", Producer = oneplus, Price = 1550 };
                Product product6 = new Product { Name = "Iphone 14", Producer = apple, Price = 2025 };

                db.Producers.AddRange(samsung, google, oneplus, apple);
                db.Products.AddRange(product1, product2, product3, product4, product5, product6);
                db.SaveChanges();
            }

           
        }
        //адмін сторінка редагування даних має бути
        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc) 
        {
            IQueryable<Product>? users = db.Products.Include(x => x.Producer);

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc: SortState.NameAsc;
            ViewData["PriceSort"] = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            ViewData["ProdSort"] = sortOrder == SortState.ProducerAsc ? SortState.ProducerDesc : SortState.ProducerAsc;

            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.Name),
                SortState.PriceAsc => users.OrderBy(s => s.Price),
                SortState.PriceDesc => users.OrderByDescending(s => s.Price),
                SortState.ProducerAsc => users.OrderBy(s => s.Producer!.Name),
                SortState.ProducerDesc => users.OrderByDescending(s => s.Producer!.Name),
                _ => users.OrderBy(s => s.Name)

            };

            IndexViewModel viewModel = new IndexViewModel
            {
                Products = await users.AsNoTracking().ToListAsync(),
                sortViewModel = new SortViewModel(sortOrder)
            };

            return View(viewModel);
        }

    }
}

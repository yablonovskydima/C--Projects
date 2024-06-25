using WebApplicationModels1.Models;

namespace WebApplicationModels1.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Person> People { get; set; } = new List<Person>();
        public IEnumerable<CompanyModel> Companies { get; set; } = new List<CompanyModel>();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<CountryModel> Countries { get; set; } = new List<CountryModel>();
    }
}

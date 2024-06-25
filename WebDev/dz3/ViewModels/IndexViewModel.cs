using dz.Models;

namespace dz.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<CountryModel> Countries { get; set; } = new List<CountryModel>();
    }
}

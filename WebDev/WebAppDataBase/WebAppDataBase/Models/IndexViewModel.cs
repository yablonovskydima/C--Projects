namespace WebAppDataBase.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products = new List<Product>();
        public SortViewModel sortViewModel { get; set; } = new SortViewModel(SortState.NameAsc);

    }
}

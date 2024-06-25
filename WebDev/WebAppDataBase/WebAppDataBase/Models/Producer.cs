namespace WebAppDataBase.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product> Products {get; set; }
    }
}

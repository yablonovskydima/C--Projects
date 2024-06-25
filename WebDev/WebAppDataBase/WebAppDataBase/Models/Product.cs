namespace WebAppDataBase.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }   
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
    }
}

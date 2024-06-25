using Microsoft.EntityFrameworkCore;

namespace WebAppDataBase.Models
{
    public class ProductsContext :DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

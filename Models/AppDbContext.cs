using Microsoft.EntityFrameworkCore;

namespace YourApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public string School { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        
    }
}
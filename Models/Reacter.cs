using Microsoft.EntityFrameworkCore;

namespace YourApp.Models
{
    public class ReacterDbContext : DbContext
    {
        public ReacterDbContext(DbContextOptions<ReacterDbContext> options)
            : base(options) { }

        public DbSet<Reacter> Reacters { get; set; }
    }

    public class Reacter
    {
        public int Id { get; set; }
        public string userid { get; set; }
        public string Command { get; set; }
        public string Date { get; set; }
    }
}
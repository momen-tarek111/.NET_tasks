using Microsoft.EntityFrameworkCore;
using project2.Models;

namespace project2.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Niki" },
                new Company { Id = 2, Name = "Adidas" });
        }
    }
}

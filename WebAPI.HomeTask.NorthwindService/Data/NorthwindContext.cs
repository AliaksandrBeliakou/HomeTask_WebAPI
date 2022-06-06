using Microsoft.EntityFrameworkCore;
using WebAPI.HomeTask.NorthwindService.Data.Entities;

namespace WebAPI.HomeTask.NorthwindService.Data
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId).HasName("ProductID");
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId).HasName("CategoryID");
        }

    }
}

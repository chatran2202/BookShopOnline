using CafeBook.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Web.Data
{
    public class CafeBookDbContext : DbContext
    {
        public CafeBookDbContext(DbContextOptions<CafeBookDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "History", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 }
                );
        }
    }
}

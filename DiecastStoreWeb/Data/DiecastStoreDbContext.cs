using DiecastStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DiecastStoreWeb.Data
{
    public class DiecastStoreDbContext : DbContext
    {
        public DiecastStoreDbContext(DbContextOptions<DiecastStoreDbContext> options) : base(options)
        {

        }

        public DbSet<CarBrand> CarBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>().HasData(
                new CarBrand { Id = 1, CarBrandName = "Porsche", DisplayOrder = 1 },
                new CarBrand { Id = 2, CarBrandName = "Mercedes-Benz", DisplayOrder = 2 },
                new CarBrand { Id = 3, CarBrandName = "Audi", DisplayOrder = 3 },
                new CarBrand { Id = 4, CarBrandName = "Volkswagen", DisplayOrder = 4 },
                new CarBrand { Id = 5, CarBrandName = "Opel", DisplayOrder = 5 },
                new CarBrand { Id = 6, CarBrandName = "BMW", DisplayOrder = 6 },
                new CarBrand { Id = 7, CarBrandName = "Renault", DisplayOrder = 7 },
                new CarBrand { Id = 8, CarBrandName = "Peugeot", DisplayOrder = 8 },
                new CarBrand { Id = 9, CarBrandName = "Citroën", DisplayOrder = 9 },
                new CarBrand { Id = 10, CarBrandName = "Aston Martin", DisplayOrder = 10 }
                );
        }
    }
}

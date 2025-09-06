using DiecastStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DiecastStore.DataAccess.Data
{
    public class DiecastStoreDbContext : DbContext
    {
        public DiecastStoreDbContext(DbContextOptions<DiecastStoreDbContext> options) : base(options)
        {

        }

        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Item> Items { get; set; }

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
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "89' Porsche 944 Turbo", Description = "Mattel Hot Wheels 1989 Porsche 944 Turbo, Porsche Series 3/6 [Black]", Price = 15.99, CarBrandId = 1 , ImageUrl = ""},
                new Item { Id = 2, Name = "'89 Mercedes-Benz 560 Sec AMG", Description = "Hot Wheels '89 Mercedes Benz 560 Sec AMG, HW Turbo 4/5 [Black] 150/250", Price = 6.84, CarBrandId = 2, ImageUrl = "" },
                new Item { Id = 3, Name = "Renault Sport R.S. 01'", Description = "Hot Wheels Renault Sport R.S. 01, HW Turbo 3/5 [red] 134/250", Price = 6.29 , CarBrandId = 7 , ImageUrl = "" }
                );
        }
    }
}

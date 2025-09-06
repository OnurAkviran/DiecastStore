using DiecastStore.DataAccess.Data;
using DiecastStore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DiecastStoreDbContext _dbContext;
        public ICarBrandRepository CarBrand { get; private set; }
        public IItemRepository Item { get; private set; }
        public UnitOfWork(DiecastStoreDbContext db)
        {
            _dbContext = db;
            CarBrand = new CarBrandRepository(_dbContext);
            Item = new ItemRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

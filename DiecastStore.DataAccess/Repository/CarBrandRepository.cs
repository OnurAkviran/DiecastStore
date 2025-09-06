using DiecastStore.DataAccess.Data;
using DiecastStore.DataAccess.Repository.IRepository;
using DiecastStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.DataAccess.Repository
{
    public class CarBrandRepository : Repository<CarBrand>, ICarBrandRepository
    {
        private DiecastStoreDbContext _dbContext;
        public CarBrandRepository(DiecastStoreDbContext db) : base(db) 
        {
            _dbContext = db;
        }

        public void Update(CarBrand entity)
        {
            _dbContext.CarBrands.Update(entity);
        }
    }
}

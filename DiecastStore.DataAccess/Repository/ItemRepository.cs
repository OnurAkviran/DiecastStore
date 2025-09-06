using DiecastStore.DataAccess.Data;
using DiecastStore.DataAccess.Repository.IRepository;
using DiecastStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.DataAccess.Repository
{
    internal class ItemRepository : Repository<Item>, IItemRepository
    {
        public DiecastStoreDbContext _dbContext;
        public ItemRepository(DiecastStoreDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public void Update(Item item)
        {
            _dbContext.Items.Update(item);
        }
    }
}

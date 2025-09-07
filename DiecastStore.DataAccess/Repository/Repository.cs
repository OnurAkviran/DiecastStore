using DiecastStore.DataAccess.Data;
using DiecastStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DiecastStore.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DiecastStoreDbContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(DiecastStoreDbContext db)
        {
            _dbContext = db;
            this.dbSet = _dbContext.Set<T>();
            _dbContext.Items.Include(u => u.CarBrand);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            query = IncludeProperties(query, includeProperties);
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            query = IncludeProperties(query, includeProperties);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
        private IQueryable<T> IncludeProperties(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return query;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

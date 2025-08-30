using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarBrandRepository CarBrand { get; }

        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookApi.Repositories.GenericRepository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        ValueTask<T> GetByIdAsync(int id);
        ValueTask AddAsync(T entity);
        void Update(T Entity);
        void Delete(T Entity);

    }
}

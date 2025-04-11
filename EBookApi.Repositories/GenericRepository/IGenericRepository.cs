using System.Linq.Expressions;

namespace EBookApi.Repositories.GenericRepository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        ValueTask<T> GetByIdAsync(int id);
        ValueTask AddAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        void Update(T Entity);
        void Delete(T Entity);

    }
}

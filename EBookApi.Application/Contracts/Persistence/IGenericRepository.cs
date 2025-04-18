using System.Linq.Expressions;

namespace EBookApi.Application.Contracts.Persistence
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        ValueTask<T> GetByIdAsync(int id);
        ValueTask AddAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    
        void Update(T Entity);
        void Delete(T Entity);

    }
}

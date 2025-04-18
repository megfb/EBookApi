using System.Linq.Expressions;
using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Persistance
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class, IEntity, new()
    {

        private readonly DbSet<T> _dbSet = context.Set<T>();
        public async ValueTask AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(T Entity)
        {
            _dbSet.Remove(Entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id)!;
        }

        public void Update(T Entity)
        {
            _dbSet.Update(Entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }
    }
}

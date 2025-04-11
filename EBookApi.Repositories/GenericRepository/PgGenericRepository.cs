using System.Linq.Expressions;
using EBookApi.Entities.Abstract;
using EBookApi.Repositories.DbServices;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Repositories.GenericRepository
{
    public class PgGenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class, IEntity, new()
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
            return _dbSet.FindAsync(id);
        }

        public void Update(T Entity)
        {
            _dbSet.Update(Entity);
        }
    }
}

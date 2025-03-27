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

namespace EBookApi.Repositories.DbUnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChanges();
    }
}

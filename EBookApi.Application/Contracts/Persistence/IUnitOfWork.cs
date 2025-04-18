namespace EBookApi.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChanges();
    }
}

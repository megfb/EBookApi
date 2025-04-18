using EBookApi.Application.Contracts.Persistence;

namespace EBookApi.Persistance
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return appDbContext.SaveChangesAsync();
        }
    }
}

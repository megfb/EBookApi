using EBookApi.Repositories.DbServices;

namespace EBookApi.Repositories.DbUnitOfWork
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return appDbContext.SaveChangesAsync();
        }
    }
}

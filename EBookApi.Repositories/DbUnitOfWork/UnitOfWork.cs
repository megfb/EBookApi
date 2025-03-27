using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

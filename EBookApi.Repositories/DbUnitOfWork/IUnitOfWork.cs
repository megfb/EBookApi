using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookApi.Repositories.DbUnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChanges();
    }
}

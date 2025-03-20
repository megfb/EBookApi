using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookApi.Entities.Entities;
using EBookApi.Repositories.GenericRepository;

namespace EBookApi.Repositories.DbEntities.Categories
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
    }
}

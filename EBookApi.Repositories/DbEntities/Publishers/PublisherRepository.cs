using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbServices;
using EBookApi.Repositories.GenericRepository;

namespace EBookApi.Repositories.DbEntities.Publishers
{
    public class PublisherRepository(AppDbContext appDbContext):PgGenericRepository<Publisher>(appDbContext), IPublisherRepository   
    {
    }
}

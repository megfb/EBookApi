using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities;
using EBookApi.Persistance;

namespace EBookApi.Persistance.Publishers
{
    public class PublisherRepository(AppDbContext appDbContext) : GenericRepository<Publisher>(appDbContext), IPublisherRepository
    {
    }
}

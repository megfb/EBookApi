using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities;

namespace EBookApi.Persistance.Publishers
{
    public class PublisherRepository(AppDbContext appDbContext) : GenericRepository<Publisher>(appDbContext), IPublisherRepository
    {
    }
}

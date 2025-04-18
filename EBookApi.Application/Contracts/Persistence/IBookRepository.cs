using EBookApi.Domain.Entities;

namespace EBookApi.Application.Contracts.Persistence
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}

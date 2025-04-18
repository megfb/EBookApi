using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities;
using EBookApi.Persistance;

namespace EBookApi.Persistance.Books
{
    public class BookRepository(AppDbContext appDbContext) : GenericRepository<Book>(appDbContext), IBookRepository
    {
    }
}

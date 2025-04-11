using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbServices;
using EBookApi.Repositories.GenericRepository;

namespace EBookApi.Repositories.DbEntities.Books
{
    public class BookRepository(AppDbContext appDbContext) : PgGenericRepository<Book>(appDbContext), IBookRepository
    {
    }
}

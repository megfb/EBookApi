using EBookApi.Entities.Entities;
using EBookApi.Repositories.GenericRepository;

namespace EBookApi.Repositories.DbEntities.Books
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}

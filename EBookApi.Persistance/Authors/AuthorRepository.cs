using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities;

namespace EBookApi.Persistance.Authors
{
    public class AuthorRepository(AppDbContext context) : GenericRepository<Author>(context), IAuthorRepository
    {
    }
}

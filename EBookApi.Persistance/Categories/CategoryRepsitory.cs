using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities;

namespace EBookApi.Persistance.Categories
{
    public class CategoryRepsitory(AppDbContext appDbContext) : GenericRepository<Category>(appDbContext), ICategoryRepository
    {
    }
}

using EBookApi.Application.Contracts.Persistence;
using EBookApi.Domain.Entities;
using EBookApi.Persistance;

namespace EBookApi.Persistance.Categories
{
    public class CategoryRepsitory(AppDbContext appDbContext) : GenericRepository<Category>(appDbContext), ICategoryRepository
    {
    }
}

using EBookApi.Application.Features.Categories.Create;
using EBookApi.Application.Features.Categories.Requests;

namespace EBookApi.Application.Features.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<List<CategoryResponse>>> GetAllAsync();
        Task<ServiceResult<CategoryResponse>> GetByIdAsync(int id);
        Task<ServiceResult<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest);
        Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest updateCategoryRequest);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

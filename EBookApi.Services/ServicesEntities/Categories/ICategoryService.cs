using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Categories.Requests;
using EBookApi.Services.ServicesEntities.Categories.Responses;

namespace EBookApi.Services.ServicesEntities.Categories
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

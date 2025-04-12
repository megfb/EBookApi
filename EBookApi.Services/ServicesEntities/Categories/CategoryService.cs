using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbEntities.Categories;
using EBookApi.Repositories.DbUnitOfWork;
using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Categories.Requests;
using EBookApi.Services.ServicesEntities.Categories.Responses;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Services.ServicesEntities.Categories
{
    public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<ServiceResult<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            var category = new Category()
            {
                Name = createCategoryRequest.Name
            };
            await categoryRepository.AddAsync(category);
            await unitOfWork.SaveChanges();
            return ServiceResult<CreateCategoryResponse>.Success(new CreateCategoryResponse(category.Id));
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult.Fail("Category not found", System.Net.HttpStatusCode.NotFound);
            }
            categoryRepository.Delete(category);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<CategoryResponse>>> GetAllAsync()
        {
            var categories = await categoryRepository.GetAll().ToListAsync();
            var categoriesAsDto = categories.Select(c => new CategoryResponse(c.Id, c.Name));
            return ServiceResult<List<CategoryResponse>>.Success(categoriesAsDto.ToList());
        }

        public async Task<ServiceResult<CategoryResponse>> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult<CategoryResponse>.Fail("Category not found", System.Net.HttpStatusCode.NotFound);
            }
            var categoryAsDto = new CategoryResponse(category.Id, category.Name);
            return ServiceResult<CategoryResponse>.Success(categoryAsDto!);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult.Fail("Category not found", System.Net.HttpStatusCode.NotFound);
            }
            category.Name = updateCategoryRequest.Name;
            categoryRepository.Update(category);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(System.Net.HttpStatusCode.NoContent);
        }
    }
}

using EBookApi.Services.ServicesEntities.Categories;
using EBookApi.Services.ServicesEntities.Categories.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.API.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : CustomBaseController
    {
        [HttpGet] public async Task<IActionResult> GetAll() => CreateActionResult(await categoryService.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest createCategoryRequest)
        {
            return CreateActionResult(await categoryService.CreateAsync(createCategoryRequest));
        }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, UpdateCategoryRequest updateCategoryRequest) => CreateActionResult(await categoryService.UpdateAsync(id, updateCategoryRequest));
        [HttpDelete] public async Task<IActionResult> Delete(int id) => CreateActionResult(await categoryService.DeleteAsync(id));
    }
}

using EBookApi.Application.Features.Authors;
using EBookApi.Application.Features.Authors.Create;
using EBookApi.Application.Features.Authors.Update;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.CleanAPI.Controllers
{
    public class AuthorsController(IAuthorService authorService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await authorService.GetAll());
        }
        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetPagedAllList(int pageNumber,int pageSize)
        {
            return CreateActionResult(await authorService.GetPagedAllListAsync(pageNumber,pageSize));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequest createAuthorRequest)
        {
            
            return CreateActionResult(await authorService.CreateAuthorAsync(createAuthorRequest));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            return CreateActionResult(await authorService.GetAuthorById(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorRequest updateAuthorRequest)
        {
            return CreateActionResult(await authorService.UpdateAuthorAsync(id, updateAuthorRequest));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            return CreateActionResult(await authorService.DeleteAuthorAsync(id));
        }
    }
}

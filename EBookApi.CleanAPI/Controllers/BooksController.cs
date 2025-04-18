using EBookApi.Application.Features.Books;
using EBookApi.Application.Features.Books.Create;
using EBookApi.Application.Features.Books.Update;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.CleanAPI.Controllers
{
    public class BooksController(IBookService bookService) : CustomBaseController
    {
        [HttpGet] public async Task<IActionResult> GetAll() => CreateActionResult(await bookService.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) => CreateActionResult(await bookService.GetByIdAsync(id));
        [HttpPost] public async Task<IActionResult> Create(CreateBookRequest createBookRequest) => CreateActionResult(await bookService.CreateAsync(createBookRequest));
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, UpdateBookRequest updateBookRequest) => CreateActionResult(await bookService.UpdateAsync(id, updateBookRequest));
        [HttpDelete] public async Task<IActionResult> Delete(int id) => CreateActionResult(await bookService.DeleteAsync(id));
    }
}

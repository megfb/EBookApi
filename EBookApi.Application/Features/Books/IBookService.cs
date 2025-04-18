using EBookApi.Application.Features.Books.Create;
using EBookApi.Application.Features.Books.Update;

namespace EBookApi.Application.Features.Books
{
    public interface IBookService
    {
        public Task<ServiceResult<List<BookResponse>>> GetAllAsync();
        public Task<ServiceResult<BookResponse>> GetByIdAsync(int id);
        public Task<ServiceResult<CreateBookResponse>> CreateAsync(CreateBookRequest createBookRequest);
        public Task<ServiceResult> UpdateAsync(int id, UpdateBookRequest updateBookRequest);
        public Task<ServiceResult> DeleteAsync(int id);

    }
}

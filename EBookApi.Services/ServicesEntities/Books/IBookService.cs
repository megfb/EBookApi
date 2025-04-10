using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Books.Requests;
using EBookApi.Services.ServicesEntities.Books.Responses;

namespace EBookApi.Services.ServicesEntities.Books
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

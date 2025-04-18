using System.Net;
using EBookApi.Application.Contracts.Persistence;
using EBookApi.Application.Features.Books.Create;
using EBookApi.Application.Features.Books.Update;
using EBookApi.Domain.Entities;

namespace EBookApi.Application.Features.Books
{
    public class BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork) : IBookService
    {
        public async Task<ServiceResult<CreateBookResponse>> CreateAsync(CreateBookRequest createBookRequest)
        {
            var book = new Book()
            {
                Name = createBookRequest.Name,
                UnitPrice = createBookRequest.UnitPrice,
                Description = createBookRequest.Description,
                CategoryId = createBookRequest.CategoryId,
                AuthorId = createBookRequest.AuthorId,
                PublisherId = createBookRequest.PublisherId
            };
            await bookRepository.AddAsync(book);
            await unitOfWork.SaveChanges();
            return ServiceResult<CreateBookResponse>.Success(new CreateBookResponse(book.Id));
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                return ServiceResult.Fail("Book not found", HttpStatusCode.NotFound);
            }
            bookRepository.Delete(book);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<BookResponse>>> GetAllAsync()
        {
            var books = await bookRepository.GetAllAsync();
            var booksAsDto = books.Select(b => new BookResponse(b.Id, b.Name, b.UnitPrice, b.Description, b.CategoryId, b.AuthorId, b.PublisherId));
            return ServiceResult<List<BookResponse>>.Success(booksAsDto.ToList());
        }

        public async Task<ServiceResult<BookResponse>> GetByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                return ServiceResult<BookResponse>.Fail("Book not found", HttpStatusCode.NotFound);
            }
            var bookAsDto = new BookResponse(book.Id, book.Name, book.UnitPrice, book.Description, book.CategoryId, book.AuthorId, book.PublisherId);
            return ServiceResult<BookResponse>.Success(bookAsDto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateBookRequest updateBookRequest)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                return ServiceResult.Fail("Book not found", HttpStatusCode.NotFound);
            }
            book.Name = updateBookRequest.Name;
            book.UnitPrice = updateBookRequest.UnitPrice;
            book.Description = updateBookRequest.Description;
            book.CategoryId = updateBookRequest.CategoryId;
            book.AuthorId = updateBookRequest.AuthorId;
            book.PublisherId = updateBookRequest.PublisherId;
            bookRepository.Update(book);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}

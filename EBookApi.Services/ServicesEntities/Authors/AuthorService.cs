using System.Net;
using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbEntities.Authors;
using EBookApi.Repositories.DbUnitOfWork;
using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Authors.Create;
using EBookApi.Services.ServicesEntities.Authors.Update;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Services.ServicesEntities.Authors
{
    public class AuthorService(IAuthorRepository _authorRepository, IUnitOfWork unitOfWork) : IAuthorService
    {
        public async Task<ServiceResult<CreateAuthorResponse>> CreateAuthorAsync(CreateAuthorRequest request)
        {
            var anyAuthor =await _authorRepository.Where(x => x.Name == request.Name).AnyAsync();
            if (anyAuthor)
            {
                return ServiceResult<CreateAuthorResponse>.Fail("The name is found in DB");
            }
            var author = new Author()
            {
                Name = request.Name,
                Biography = request.Biography,
            };

            await _authorRepository.AddAsync(author);
            await unitOfWork.SaveChanges();
            return ServiceResult<CreateAuthorResponse>.Success(new CreateAuthorResponse(author.Id));
        }

        public async Task<ServiceResult> DeleteAuthorAsync(int id)
        {
            var author = _ = await _authorRepository.GetByIdAsync(id);
            if (author is null)
            {
                return ServiceResult.Fail("Author not found", HttpStatusCode.NotFound);
            }
            _authorRepository.Delete(author);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult<List<AuthorResponse>>> GetAll()
        {
            var authors = await _authorRepository.GetAll().ToListAsync();
            var authorsAsDto = authors.Select(a => new AuthorResponse(a.Id, a.Name, a.Biography)).ToList();
            return ServiceResult<List<AuthorResponse>>.Success(authorsAsDto);
        }

        public async Task<ServiceResult<AuthorResponse>> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            var authorAsDto = new AuthorResponse(author.Id, author.Name, author.Biography);

            if (author is null)
            {
                return ServiceResult<AuthorResponse>.Fail("Author not found", HttpStatusCode.NotFound);
            }
            return ServiceResult<AuthorResponse>.Success(authorAsDto!);

        }

        public async Task<ServiceResult<List<AuthorResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            var authors = await _authorRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var authorsAsDto = authors.Select(a => new AuthorResponse(a.Id, a.Name, a.Biography)).ToList();
            return ServiceResult<List<AuthorResponse>>.Success(authorsAsDto.ToList());
        }

        public async Task<ServiceResult> UpdateAuthorAsync(int id, UpdateAuthorRequest request)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author is null)
            {
                return ServiceResult.Fail("author not found", HttpStatusCode.NotFound);
            }
            author.Name = request.Name;
            author.Biography = request.Biography;
            _authorRepository.Update(author);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }



    }
}

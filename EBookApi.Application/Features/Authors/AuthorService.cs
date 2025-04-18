using System.Net;
using AutoMapper;
using EBookApi.Application.Contracts.Persistence;
using EBookApi.Application.Features.Authors.Create;
using EBookApi.Application.Features.Authors.Update;
using EBookApi.Domain.Entities;

namespace EBookApi.Application.Features.Authors
{
    public class AuthorService(IAuthorRepository _authorRepository, IUnitOfWork unitOfWork, IMapper mapper) : IAuthorService
    {
        public async Task<ServiceResult<CreateAuthorResponse>> CreateAuthorAsync(CreateAuthorRequest request)
        {
            var anyAuthor = await _authorRepository.AnyAsync(x => x.Name == request.Name);
            if (anyAuthor)
            {
                return ServiceResult<CreateAuthorResponse>.Fail("The name is found in DB");
            }
            var author = mapper.Map<Author>(request);

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

            var authors = await _authorRepository.GetAllAsync();
            //var authorsAsDto = authors.Select(a => new AuthorResponse(a.Id, a.Name, a.Biography)).ToList(); ---->>>>>>>> Manuel Mapping
            var authorsAsDto = mapper.Map<List<AuthorResponse>>(authors);
            return ServiceResult<List<AuthorResponse>>.Success(authorsAsDto);
        }

        public async Task<ServiceResult<AuthorResponse>> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            //var authorAsDto = new AuthorResponse(author.Id, author.Name, author.Biography);
            var authorAsDto = mapper.Map<AuthorResponse>(author);

            if (author is null)
            {
                return ServiceResult<AuthorResponse>.Fail("Author not found", HttpStatusCode.NotFound);
            }
            return ServiceResult<AuthorResponse>.Success(authorAsDto!);

        }

        public async Task<ServiceResult<List<AuthorResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            var authors = await _authorRepository.GetAllPagedAsync(pageNumber, pageSize);
            //var authorsAsDto = authors.Select(a => new AuthorResponse(a.Id, a.Name, a.Biography)).ToList();
            var authorsAsDto = mapper.Map<List<AuthorResponse>>(authors);
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
            //mapper.Map(request,author);
            mapper.Map<Author>(request);
            _authorRepository.Update(author);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }



    }
}

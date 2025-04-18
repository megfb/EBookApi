using EBookApi.Application.Features.Authors.Create;
using EBookApi.Application.Features.Authors.Update;

namespace EBookApi.Application.Features.Authors
{
    public interface IAuthorService
    {
        public Task<ServiceResult<List<AuthorResponse>>> GetAll();
        public Task<ServiceResult<AuthorResponse>> GetAuthorById(int id);
        public Task<ServiceResult<CreateAuthorResponse>> CreateAuthorAsync(CreateAuthorRequest request);
        public Task<ServiceResult> UpdateAuthorAsync(int id, UpdateAuthorRequest request);
        public Task<ServiceResult> DeleteAuthorAsync(int id);
        public Task<ServiceResult<List<AuthorResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);

    }
}

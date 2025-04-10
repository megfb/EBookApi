﻿using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Authors.Create;
using EBookApi.Services.ServicesEntities.Authors.Update;

namespace EBookApi.Services.ServicesEntities.Authors
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

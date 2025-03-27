using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbEntities.Authors;
using EBookApi.Services.Results;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Services.ServicesEntities.Authors
{
    public class AuthorService(IAuthorRepository _authorRepository) : IAuthorService
    {
        public async Task<ServiceResult<List<Author>>> GetAll()
        {
            var author = await _authorRepository.GetAll().ToListAsync();
            return new ServiceResult<List<Author>>()
            {
                Data = author,


            };
        }

        public async Task<ServiceResult<Author>> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author is null)
            {
                ServiceResult<Author>.Fail("Author nod found",HttpStatusCode.NotFound);
            }
            return ServiceResult<Author>.Success(author);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookApi.Entities.Entities;
using EBookApi.Services.Results;

namespace EBookApi.Services.ServicesEntities.Authors
{
    public interface IAuthorService
    {
        public Task<ServiceResult<List<Author>>> GetAll();
        public Task<ServiceResult<Author>> GetAuthorById(int id);

    }
}

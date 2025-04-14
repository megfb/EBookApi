using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EBookApi.Entities.Entities;
using EBookApi.Services.ServicesEntities.Authors;
using EBookApi.Services.ServicesEntities.Authors.Create;

namespace EBookApi.Services.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<CreateAuthorRequest, Author>();

        }
    }
}

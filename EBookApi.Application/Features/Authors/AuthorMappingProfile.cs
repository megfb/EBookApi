using AutoMapper;
using EBookApi.Application.Features.Authors.Create;
using EBookApi.Application.Features.Authors.Update;
using EBookApi.Domain.Entities;

namespace EBookApi.Application.Features.Authors
{
    public class AuthorMappingProfile:Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<CreateAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();

        }
    }
}

using AutoMapper;
using BlogAPI.Core.Application.Dtos;
using BlogAPI.Core.Domain.Entidades;

namespace BlogAPI.Core.Application.Mapeamentos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}

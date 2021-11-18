using System.Collections.Generic;
using AutoMapper;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Models.Request.Comment;
using BrowserBlog.Browsers.WebApi.Models.Response.Comment;

namespace BrowserBlog.Browsers.WebApi.Configuration.Mappers
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<CommentCreate, CommentDto>();
            CreateMap<CommentDto, CommentListItem>();
            CreateMap<ICollection<CommentDto>, CommentList>()
                .ForMember(dest => dest.Comments, 
                    opt => opt.MapFrom(src => src));
        }
    }
}
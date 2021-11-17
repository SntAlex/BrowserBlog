using AutoMapper;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using BrowserBlog.Browsers.WebApi.Models.Response.BrowserPage;

namespace BrowserBlog.Browsers.WebApi.Configuration.Mappers
{
    public class BrowserPageMapper : Profile
    {
        public BrowserPageMapper()
        {
            CreateMap<BrowserPageDto, BrowserPageDetailed>()
                .ForMember(dest => dest.CommentsList,
                    opt => opt.MapFrom(src => src.Comments));
            CreateMap<BrowserCreate, BrowserPageDto>().ForMember(dest => dest.Browser, 
                opt => opt.MapFrom(src => src));
        }
    }
}
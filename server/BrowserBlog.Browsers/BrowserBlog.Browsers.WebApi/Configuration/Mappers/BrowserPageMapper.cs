using System.Collections.Generic;
using AutoMapper;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using BrowserBlog.Browsers.WebApi.Models.Response.Browser;
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
            CreateMap<BrowserPageCreate, BrowserPageDto>();
            CreateMap<BrowserPageUpdate, BrowserPageDto>();
            CreateMap<BrowserPageDto, BrowserTitlesListItem>();
            CreateMap<ICollection<BrowserPageDto>, BrowserTitlesList>()
                .ForMember(dest => dest.Browsers, 
                    opt => opt.MapFrom(src => src));
        }
    }
}
using System.Collections.Generic;
using AutoMapper;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using BrowserBlog.Browsers.WebApi.Models.Response.Browser;

namespace BrowserBlog.Browsers.WebApi.Configuration.Mappers
{
    public class BrowserMapper : Profile
    {
        public BrowserMapper()
        {
            CreateMap<BrowserCreate, BrowserDto>();
            CreateMap<BrowserUpdate, BrowserDto>();
            CreateMap<BrowserDto, BrowserListItem>();
            CreateMap<ICollection<BrowserDto>, BrowserList>()
                .ForMember(dest => dest.Browsers, 
                    opt => opt.MapFrom(src => src));
            CreateMap<BrowserDto, BrowserDetailed>();
        }
    }
}
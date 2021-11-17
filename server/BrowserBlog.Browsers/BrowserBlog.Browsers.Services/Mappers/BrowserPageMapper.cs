using AutoMapper;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.Domain.Models.Entities;

namespace BrowserBlog.Browsers.Services.Mappers
{
    public class BrowserPageMapper : Profile
    {
        public BrowserPageMapper()
        {
            CreateMap<BrowserPage, BrowserPageDto>()
                .ReverseMap();
        }
    }
}
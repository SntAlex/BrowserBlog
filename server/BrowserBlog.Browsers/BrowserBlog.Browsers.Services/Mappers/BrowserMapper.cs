using AutoMapper;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.Domain.Models.Entities;

namespace BrowserBlog.Browsers.Services.Mappers
{
    public class BrowserMapper : Profile
    {
        public BrowserMapper()
        {
            CreateMap<Browser, BrowserDto>()
                .ReverseMap();
        }
    }
}
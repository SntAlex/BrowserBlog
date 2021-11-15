using System.Threading.Tasks;
using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Controllers.Base;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using Microsoft.AspNetCore.Mvc;

namespace BrowserBlog.Browsers.WebApi.Controllers
{
    public class BrowserController : BaseController
    {
        private readonly IBrowserService _browserService;

        public BrowserController(IMapper mapper, IBrowserService browserService) : base(mapper)
        {
            _browserService = browserService;
        }

        public async Task<ActionResult> CreateBrowser(BrowserToCreate browser)
        {
            var browserDto = Mapper.Map<BrowserDto>(browser);
            var result = await _browserService.AddBrowserAsync(browserDto);
            return Ok();
        }

        public async Task<ActionResult> GetBrowserNames

    }
}

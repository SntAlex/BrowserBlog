using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Controllers.Base;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using BrowserBlog.Browsers.WebApi.Models.Response.Browser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.WebApi.Controllers.v1
{
    public class BrowserController : BaseController
    {
        private readonly IBrowserService _browserService;

        public BrowserController(IMapper mapper, IBrowserService browserService) : base(mapper)
        {
            _browserService = browserService;
        }

        [HttpGet]
        public ActionResult<BrowserList> GetBrowserList()
        {
            var serviceResult = _browserService.GetBrowsersList();

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok(Mapper.Map<BrowserList>(serviceResult.Data));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBrowser(BrowserUpdate browser)
        {
            var serviceResult = await _browserService.UpdateBrowser(Mapper.Map<BrowserDto>(browser));

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok();
        }
    }
}
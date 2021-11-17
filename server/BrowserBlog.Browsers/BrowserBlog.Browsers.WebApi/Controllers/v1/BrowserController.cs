using System;
using System.Threading.Tasks;
using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Controllers.Base;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using BrowserBlog.Browsers.WebApi.Models.Response.Browser;
using Microsoft.AspNetCore.Mvc;

namespace BrowserBlog.Browsers.WebApi.Controllers.v1
{
    public class BrowserController : BaseController
    {
        private readonly IBrowserService _browserService;

        public BrowserController(IMapper mapper, IBrowserService browserService) : base(mapper)
        {
            _browserService = browserService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrowser(BrowserCreate browser)
        {
            var serviceResult = await _browserService.AddBrowserAsync(Mapper.Map<BrowserDto>(browser));
            
            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Guid>> GetBrowser(Guid id)
        {
            var serviceResult = await _browserService.GetBrowser(id);

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok(Mapper.Map<BrowserDetailed>(serviceResult.Data));
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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBrowser(Guid id)
        {
            var serviceResult = await _browserService.DeleteBrowser(id);

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok();
        }
    }
}
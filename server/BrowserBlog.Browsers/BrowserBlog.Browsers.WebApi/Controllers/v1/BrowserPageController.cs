using System;
using System.Threading.Tasks;
using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.WebApi.Controllers.Base;
using BrowserBlog.Browsers.WebApi.Models.Request.Browser;
using BrowserBlog.Browsers.WebApi.Models.Request.Comment;
using BrowserBlog.Browsers.WebApi.Models.Response.BrowserPage;
using Microsoft.AspNetCore.Mvc;

namespace BrowserBlog.Browsers.WebApi.Controllers.v1
{
    public class BrowserPageController : BaseController
    {
        private readonly IBrowserPageService _browserPageService;

        public BrowserPageController(IMapper mapper, IBrowserPageService browserPageService) : base(mapper)
        {
            _browserPageService = browserPageService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BrowserPageDetailed>> GetBrowserPage(Guid id)
        {
            var serviceResult = await _browserPageService.GetBrowserPage(id);

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok(Mapper.Map<BrowserPageDetailed>(serviceResult.Data));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrowserPage(BrowserCreate browserPage)
        {
            var serviceResult = await _browserPageService.CreateBrowserPage(Mapper.Map<BrowserPageDto>(browserPage));

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok();
        }

        [HttpPost("Comment/{id:guid}")]
        public async Task<ActionResult> AddComment(Guid id, CommentCreate comment)
        {
            var serviceResult = await _browserPageService.AddComment(id, Mapper.Map<CommentDto>(comment));

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBrowserPage(Guid id)
        {
            var serviceResult = await _browserPageService.DeleteBrowserPage(id);

            if (!serviceResult.IsSuccessful)
            {
                return GetErrorResult(serviceResult.Error.ErrorMessage, serviceResult.Error.StatusCode);
            }

            return Ok();
        }
    }
}
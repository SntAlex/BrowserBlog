using BrowserBlog.Browsers.Domain.Contracts.Services.Base;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.Domain.Contracts.Services
{
    public interface IBrowserPageService : IBaseService
    {
        Task<OperationResult> CreateBrowserPage(BrowserPageDto browserPageDto);
        Task<OperationResult> DeleteBrowserPage(Guid id);
        Task<OperationResult> AddComment(Guid browserPageId, CommentDto commentDto);
        Task<OperationResult<BrowserPageDto>> GetBrowserPage(Guid id);
        OperationResult<ICollection<BrowserPageDto>> GetBrowsersTitlesList();
        Task<OperationResult> UpdateBrowserPage(BrowserPageDto browserPageDto);
    }
}
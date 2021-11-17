using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrowserBlog.Browsers.Domain.Contracts.Services.Base;
using BrowserBlog.Browsers.Domain.Models.Dtos;

namespace BrowserBlog.Browsers.Domain.Contracts.Services
{
    public interface IBrowserService : IBaseService
    {
        OperationResult<IEnumerable<BrowserDto>> GetBrowsersList();
        Task<OperationResult<BrowserDto>> GetBrowser(Guid id);
        Task<OperationResult> AddBrowserAsync(BrowserDto browserDto);
        Task<OperationResult> UpdateBrowser(BrowserDto browserDto);
        Task<OperationResult> DeleteBrowser(Guid id);
    }
}
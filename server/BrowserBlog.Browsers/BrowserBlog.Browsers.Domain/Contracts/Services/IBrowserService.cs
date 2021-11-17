using BrowserBlog.Browsers.Domain.Contracts.Services.Base;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.Domain.Contracts.Services
{
    public interface IBrowserService : IBaseService
    {
        OperationResult<IEnumerable<BrowserDto>> GetBrowsersList();
        Task<OperationResult> UpdateBrowser(BrowserDto browserDto);
    }
}
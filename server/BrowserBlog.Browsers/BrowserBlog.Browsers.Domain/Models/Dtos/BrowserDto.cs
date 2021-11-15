using BrowserBlog.Browsers.Domain.Models.Dtos.Base;

namespace BrowserBlog.Browsers.Domain.Models.Dtos
{
    public class BrowserDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
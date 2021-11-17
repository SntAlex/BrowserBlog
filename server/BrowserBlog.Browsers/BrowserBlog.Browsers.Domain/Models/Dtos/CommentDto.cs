using BrowserBlog.Browsers.Domain.Models.Dtos.Base;

namespace BrowserBlog.Browsers.Domain.Models.Dtos
{
    public class CommentDto : BaseDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
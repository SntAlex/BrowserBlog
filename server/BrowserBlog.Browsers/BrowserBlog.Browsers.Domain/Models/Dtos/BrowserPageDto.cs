using System.Collections.Generic;
using BrowserBlog.Browsers.Domain.Models.Dtos.Base;

namespace BrowserBlog.Browsers.Domain.Models.Dtos
{
    public class BrowserPageDto : BaseDto
    {
        public BrowserDto Browser { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
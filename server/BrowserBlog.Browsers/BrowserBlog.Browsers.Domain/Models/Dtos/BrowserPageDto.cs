using System.Collections.Generic;
using BrowserBlog.Browsers.Domain.Models.Dtos.Base;

namespace BrowserBlog.Browsers.Domain.Models.Dtos
{
    public class BrowserPageDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;

namespace BrowserBlog.Browsers.Domain.Models.Entities
{
    public class BrowserPage : BaseEntity
    {
        [Required]
        public virtual Browser Browser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
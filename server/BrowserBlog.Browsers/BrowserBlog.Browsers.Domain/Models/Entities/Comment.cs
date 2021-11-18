using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace BrowserBlog.Browsers.Domain.Models.Entities
{
    public sealed class Comment : BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string Name { get; private set; }
        [Required]
        [StringLength(1000)]
        public string Content { get; private set; }
    }
}
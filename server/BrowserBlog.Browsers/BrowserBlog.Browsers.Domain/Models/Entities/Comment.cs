using System.ComponentModel.DataAnnotations;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;

namespace BrowserBlog.Browsers.Domain.Models.Entities
{
    public sealed class Comment : BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }
    }
}
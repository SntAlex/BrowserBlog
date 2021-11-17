using BrowserBlog.Browsers.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BrowserBlog.Browsers.Domain.Models.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Browser : BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string Name { get; private set; }
        [StringLength(1000)]
        public string Description { get; private set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using BrowserBlog.Browsers.Domain.Models.Entities.Base;

namespace BrowserBlog.Browsers.Domain.Models.Entities
{
    public class Browser : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
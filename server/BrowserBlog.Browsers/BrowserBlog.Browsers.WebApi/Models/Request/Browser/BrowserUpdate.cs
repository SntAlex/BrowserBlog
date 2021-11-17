using System;
using System.ComponentModel.DataAnnotations;

namespace BrowserBlog.Browsers.WebApi.Models.Request.Browser
{
    public class BrowserUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
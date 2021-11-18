using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BrowserBlog.Browsers.WebApi.Models.Request.BrowserPage
{
    public class BrowserPageUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [NotNull]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
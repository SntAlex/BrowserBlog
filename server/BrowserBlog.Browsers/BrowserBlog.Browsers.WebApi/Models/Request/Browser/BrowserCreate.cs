using System.ComponentModel.DataAnnotations;

namespace BrowserBlog.Browsers.WebApi.Models.Request.Browser
{
    public class BrowserCreate
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
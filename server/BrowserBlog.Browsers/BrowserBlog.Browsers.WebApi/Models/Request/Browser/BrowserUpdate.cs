using System;

namespace BrowserBlog.Browsers.WebApi.Models.Request.Browser
{
    public class BrowserUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
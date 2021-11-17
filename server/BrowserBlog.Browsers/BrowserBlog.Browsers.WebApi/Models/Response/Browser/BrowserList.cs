using System.Collections.Generic;

namespace BrowserBlog.Browsers.WebApi.Models.Response.Browser
{
    public class BrowserList
    {
        public ICollection<BrowserListItem> Browsers { get; set; }
        public int BrowsersCount => Browsers.Count;
    }
}
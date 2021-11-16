using System.Collections.Generic;
using System.Linq;

namespace BrowserBlog.Browsers.WebApi.Models.Response.Browser
{
    public class BrowserList
    {
        public IEnumerable<BrowserListItem> Browsers { get; set; }
        public int Count => Browsers.Count();
    }
}
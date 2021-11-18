using System.Collections.Generic;

namespace BrowserBlog.Browsers.WebApi.Models.Response.Browser
{
    public class BrowserTitlesList
    {
        public ICollection<BrowserTitlesListItem> Browsers { get; set; }
        public int BrowsersCount => Browsers.Count;
    }
}
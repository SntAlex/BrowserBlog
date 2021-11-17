using BrowserBlog.Browsers.WebApi.Models.Response.Browser;
using BrowserBlog.Browsers.WebApi.Models.Response.Comment;

namespace BrowserBlog.Browsers.WebApi.Models.Response.BrowserPage
{
    public class BrowserPageDetailed
    {
        public BrowserDetailed Browser { get; set; }
        public CommentList CommentsList { get; set; }
    }
}
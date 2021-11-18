using BrowserBlog.Browsers.WebApi.Models.Response.Comment;

namespace BrowserBlog.Browsers.WebApi.Models.Response.BrowserPage
{
    public class BrowserPageDetailed
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CommentList CommentsList { get; set; }
    }
}
using System.Collections.Generic;

namespace BrowserBlog.Browsers.WebApi.Models.Response.Comment
{
    public class CommentList
    {
        public ICollection<CommentListItem> Comments { get; set; }
        public int CommentsCount => Comments.Count;
    }
}
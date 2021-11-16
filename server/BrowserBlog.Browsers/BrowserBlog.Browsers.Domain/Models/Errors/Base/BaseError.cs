namespace BrowserBlog.Browsers.Domain.Models.Errors.Base
{
    public abstract class BaseError
    {
        public string ErrorMessage { get; set; }
        public virtual int StatusCode { get; set; }
    }
}
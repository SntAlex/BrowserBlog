using BrowserBlog.Browsers.Domain.Models.Errors.Base;

namespace BrowserBlog.Browsers.Domain.Models.Errors
{
    public class BadRequestError : BaseError
    {
        public override int StatusCode => 400;

        public BadRequestError(string message)
        {
            ErrorMessage = message;
        }
    }
}
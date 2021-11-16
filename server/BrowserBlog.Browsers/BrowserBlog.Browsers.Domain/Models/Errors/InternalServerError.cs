using BrowserBlog.Browsers.Domain.Models.Errors.Base;

namespace BrowserBlog.Browsers.Domain.Models.Errors
{
    public class InternalServerError : BaseError
    {
        public override int StatusCode => 500;

        public InternalServerError(string message)
        {
            ErrorMessage = message;
        }

        public InternalServerError()
        {
            ErrorMessage = "Internal server error";
        }
    }
}
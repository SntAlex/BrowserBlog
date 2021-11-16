using BrowserBlog.Browsers.Domain.Models.Errors.Base;
using System;

namespace BrowserBlog.Browsers.Domain.Models.Errors
{
    public class NotFoundError : BaseError
    {
        public override int StatusCode => 404;

        public NotFoundError(string message)
        {
            ErrorMessage = message;
        }

        public NotFoundError(Guid entityId)
        {
            ErrorMessage = $"Entity {entityId} not found";
        }
    }
}
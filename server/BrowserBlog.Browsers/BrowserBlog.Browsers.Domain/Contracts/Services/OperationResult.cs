using BrowserBlog.Browsers.Domain.Models.Errors.Base;

namespace BrowserBlog.Browsers.Domain.Contracts.Services
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public BaseError Error { get; set; }

        public OperationResult()
        {
            IsSuccessful = true;
        }

        public OperationResult(BaseError error)
        {
            IsSuccessful = false;
            Error = error;
        }
    }

    public class OperationResult<TData> : OperationResult
    {
        public TData Data { get; set; }

        public OperationResult(BaseError error) : base(error)
        {

        }

        public OperationResult(TData data)
        {
            Data = data;
        }
    }
}
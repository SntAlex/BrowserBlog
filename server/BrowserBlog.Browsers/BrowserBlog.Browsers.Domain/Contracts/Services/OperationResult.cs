namespace BrowserBlog.Browsers.Domain.Contracts.Services
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        public OperationResult()
        {
            IsSuccessful = true;
        }

        public OperationResult(string message)
        {
            IsSuccessful = false;
            ErrorMessage = message;
        }
    }

    public class OperationResult<TData> : OperationResult
    {
        public TData Data { get; set; }

        public OperationResult(string message) : base(message)
        {

        }

        public OperationResult(TData data)
        {
            Data = data;
        }
    }
}
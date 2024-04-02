namespace API.Classi.Utility
{
    public class OperationResult(bool isSuccess, string message = "")
    {
        public bool IsSuccess { get; } = isSuccess;
        public string Message { get; } = message;
    }

    public class OperationResult<T>(bool isSuccess, string message, T? data = default) : OperationResult(isSuccess, message)
    {
        public T Data { get; } = data;
    }

}

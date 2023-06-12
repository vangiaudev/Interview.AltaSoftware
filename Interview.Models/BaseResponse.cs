namespace Interview.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse(T data)
        {
            StatusCode = (int)CodeResponse.Success;
            Data = data;
            Message = string.Empty;
        }

        public BaseResponse(T? data, string code, string message)
        {
            int.TryParse(code, out int c);
            StatusCode = c;
            Data = data;
            Message = message;
        }

        public int StatusCode { get; set; }

        public T? Data { get; set; }

        public string Message { get; set; }
    }

    public enum CodeResponse
    {
        Success = 1,
        Error = 0
    }
}
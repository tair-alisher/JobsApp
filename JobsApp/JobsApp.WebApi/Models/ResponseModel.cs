namespace JobsApp.WebApi.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResponseModel<T> Fail(string message = "")
        {
            return new ResponseModel<T>
            {
                IsSuccess = false,
                Message = message
            };
        }

        public static ResponseModel<T> Success(T data, string message = "")
        {
            return new ResponseModel<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message
            };
        }
    }
}
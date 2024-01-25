namespace API_EF_Hash_Token.API.ApiResponse
{
    public class ApiResponse<T> where T : class
    {
     
        private ApiResponse(string message = "")
        {
            this.Message = message;
            this.IsSuccess = false;
        }
        public ApiResponse(T data, string message)
        {
            this.Data = data;
            this.Message = message;
            this.IsSuccess = true;
        }
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }
        public T? Data { get; init; }
        public static ApiResponse<T> Success(T data, string message = "")
        {
            return new ApiResponse<T>(data, message);
        }

        public static ApiResponse<T> Failed(string message = "")
        {
            return new ApiResponse<T>(message);
        }
    }
}

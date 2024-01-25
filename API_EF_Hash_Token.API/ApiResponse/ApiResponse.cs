namespace API_EF_Hash_Token.API.ApiResponse
{
    public class ApiResponse<T> where T : class
    {
        public string? Message { get; init; }
        public bool IsSuccess { get; init; }
        public T? Data { get; init; }
        public int Status { get; init; }
        private ApiResponse(bool isSuccess, string? message, int status) { this.IsSuccess = isSuccess; this.Message = message; this.Status = status;  }

        private ApiResponse(T? data, bool isSuccess, string? message, int status) : this(isSuccess, message, status) 
        {
            this.Data = data;
         
        }


        public static ApiResponse<T> Success(T data, bool isSuccess = true, string? message = "Success", int status = 200)
        {
            return new ApiResponse<T>(data, isSuccess, message, status);
        }

        public static ApiResponse<T> Failed(bool isSuccess = false, string? message = "Error", int status = 400)
        {
            return new ApiResponse<T>(isSuccess, message, status);
        }

    }
}

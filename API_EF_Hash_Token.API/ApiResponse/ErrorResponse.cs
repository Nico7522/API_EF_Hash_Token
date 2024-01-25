namespace API_EF_Hash_Token.API.ApiResponse
{
    public class ErrorResponse
    {
        public string Message { get; init; }
        public bool IsSuccess { get; init; }

        public ErrorResponse(bool isFailed = true, string message = "Error")
        {
            this.IsSuccess = isFailed;
            this.Message = message;
        }
    }
}

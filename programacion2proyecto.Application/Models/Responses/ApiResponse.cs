namespace programacion2proyecto.Application.Models.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSucces { get; set; }
        //public string Message { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;

        public int StatusCode { get; set; }

        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, int statuscode = 200)
        {
            return new ApiResponse<T>
            {
                IsSucces = true,
                Data = data,
                StatusCode = statuscode
            };
        }

        public static ApiResponse<T> FailureResponse(string errorMessage, int statuscode = 400)
        {
            return new ApiResponse<T>
            {
                IsSucces = false,
                ErrorMessage = errorMessage,
                StatusCode = statuscode,

            };
        }
    }
}

using System.Net;

namespace YSPT.Configurations.Common;

public class ApiResponse<T>
{
    public string Message { get; set; } = "No message";
    public int Status { get; set; }
    public T? Data { get; set; } = default;
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
    public bool IsOk => Status == (int)HttpStatusCode.OK;
    public bool IsNotOk => !IsOk;
    public bool IsFormValidationError => Status == (int)HttpStatusCode.BadRequest && Errors.Count > 0;
}

public static class ApiResponse
{
    public static ApiResponse<T> NoResponse<T>(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = "Unable to get valid response")
    {
        return new ApiResponse<T>()
        {
            Message = message,
            Status = (int)statusCode,
            Data = default,
        };
    }

    public static ApiResponse<T> InvalidResponse<T>(HttpStatusCode statusCode, string message = "Unable to get valid response")
    {
        return new ApiResponse<T>()
        {
            Message = message,
            Status = (int)statusCode,
            Data = default,
        };
    }

    public static ApiResponse<T> UnexpectedResponse<T>(HttpStatusCode statusCode = HttpStatusCode.SeeOther, string message = "Unexpected error occurred")
    {
        return new ApiResponse<T>()
        {
            Message = message,
            Status = (int)statusCode,
            Data = default,
        };
    }

    public static ApiResponse<T> UnAuthorized<T>()
    {
        return new ApiResponse<T>()
        {
            Message = "Not logged in",
            Status = (int)HttpStatusCode.Unauthorized,
            Data = default,
        };
    }
}

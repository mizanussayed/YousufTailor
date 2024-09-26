using System.Net;

namespace YSPT.Configurations.Common;

public class EmptyApiResponse : ApiResponse<object?>
{
    public static EmptyApiResponse NoResponse(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = "Unable to get valid response")
    {
        return new EmptyApiResponse
        {
            Message = message,
            Status = (int)statusCode,
            Data = default,
        };
    }

    public static EmptyApiResponse InvalidResponse(HttpStatusCode statusCode, string message = "Unable to get valid response")
    {
        return new EmptyApiResponse()
        {
            Message = message,
            Status = (int)statusCode,
            Data = default,
        };
    }

    public static EmptyApiResponse UnexpectedResponse(HttpStatusCode statusCode = HttpStatusCode.RequestedRangeNotSatisfiable, string message = "Unexpected error occurred")
    {
        return new EmptyApiResponse()
        {
            Message = message,
            Status = (int)statusCode,
            Data = default,
        };
    }

    public static EmptyApiResponse UnAuthorized()
    {
        return new EmptyApiResponse()
        {
            Message = "Not logged in",
            Status = (int)HttpStatusCode.Unauthorized,
            Data = default,
        };
    }
}

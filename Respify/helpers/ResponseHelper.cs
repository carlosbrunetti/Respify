namespace Respify.helpers;

public class ResponseHelper
{
    public static RespifyResponse<PaginatedData<T>> Success<T>(PaginatedData<T> data, string message, int statusCode = 200)
    {
        return new RespifyResponse<PaginatedData<T>>(data, message, true, statusCode, null);
    }
    
    public static RespifyResponse<NonPaginatedData<T>> Success<T>(NonPaginatedData<T> data, string message, int statusCode = 200)
    {
        return new RespifyResponse<NonPaginatedData<T>>(data, message, true, statusCode, null);
    }

    // public static HttpResponseHelper<T> Success<T>(T data, string message, int statusCode = 200)
    // {
    //     return new HttpResponseHelper<T>(data, message, true, statusCode, null);
    // }
    
    public static RespifyResponse<T> Failure<T>(T? data, string message, List<string> errors, int statusCode = 400)
    {
        return new RespifyResponse<T>(data, message, false, statusCode, errors);
    }
}
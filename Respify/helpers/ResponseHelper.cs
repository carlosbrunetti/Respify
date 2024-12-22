using Respify.Interfaces;

namespace Respify.helpers;

public class ResponseHelper
{
    public static RespifyResponse<IPaginatedResponse<T>> Success<T>(PaginatedResponse<T> response, string message, int statusCode = 200)
    {
        return new RespifyResponse<IPaginatedResponse<T>>(response, message, true, statusCode, null);
    }
    
    public static RespifyResponse<INonPaginatedResponse<T>> Success<T>(NonPaginatedResponse<T> response, string message, int statusCode = 200)
    {
        return new RespifyResponse<INonPaginatedResponse<T>>(response, message, true, statusCode, null);
    }
    
    public static RespifyResponse<T> CreateResponse<T>(T data, string message, int statusCode, bool success, List<string> errors)
    {
        return new RespifyResponse<T>(data, message, success, statusCode, errors);
    }
    
    public static RespifyResponse<T> Failure<T>(T? data, string message, int statusCode = 400)
    {
        return new RespifyResponse<T>(data, message, false, statusCode);
    }
    public static RespifyResponse<T> Failure<T>(T? data, string message, List<string> errors, int statusCode = 400)
    {
        return new RespifyResponse<T>(data, message, false, statusCode, errors);
    }
}
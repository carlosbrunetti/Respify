using System.Text.Json.Serialization;
using Respify.Interfaces;

namespace Respify;

public class RespifyResponse<T>: IRespifyResponse<T>
{
    public RespifyResponse(T? data, string? message, bool success, int statusCode, List<string>? errors)
    {
        Data = data;
        Message = message;
        Success = success;
        StatusCode = statusCode;
        Errors = errors;
    }
    
    public RespifyResponse(T? data, string message, bool success, int statusCode)
    {
        Data = data;
        Message = message;
        Success = success;
        StatusCode = statusCode;
    }
    
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    [JsonIgnore]
    public int StatusCode { get; set; }
    public List<string>? Errors { get; set; }
}
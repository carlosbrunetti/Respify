using System.Text.Json.Serialization;
using Respify.Interfaces;

namespace Respify;

public class RespifyResponse<T>(T? data, string? message, bool success, int statusCode, List<string>? errors)
    : IHttpResponse<T>
{
    public T? Data { get; set; } = data;
    public string? Message { get; set; } = message;
    public bool Success { get; set; } = success;
    [JsonIgnore]
    public int StatusCode { get; set; } = statusCode;
    public List<string>? Errors { get; set; } = errors;
}
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Respify.Interfaces;

namespace Respify;

/// <summary>
/// Represents a standardized response object used in the Respify framework.
/// </summary>
/// <typeparam name="T">The type of the data being returned in the response.</typeparam>
public class RespifyResponse<T> : IRespifyResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RespifyResponse{T}"/> class.
    /// </summary>
    /// <param name="data">The data being returned in the response.</param>
    /// <param name="message">The message associated with the response.</param>
    /// <param name="success">A value indicating whether the response indicates a successful operation.</param>
    /// <param name="statusCode">The HTTP status code associated with the response.</param>
    /// <param name="errors">A list of errors associated with the response.</param>
    public RespifyResponse(T? data, string? message, bool success, int statusCode, List<string>? errors)
    {
        Data = data;
        Message = message;
        Success = success;
        StatusCode = statusCode;
        Errors = errors;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RespifyResponse{T}"/> class.
    /// </summary>
    /// <param name="data">The data being returned in the response.</param>
    /// <param name="message">The message associated with the response.</param>
    /// <param name="success">A value indicating whether the response indicates a successful operation.</param>
    /// <param name="statusCode">The HTTP status code associated with the response.</param>
    public RespifyResponse(T? data, string message, bool success, int statusCode)
    {
        Data = data;
        Message = message;
        Success = success;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Gets or sets the data being returned in the response.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the response.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the response indicates a successful operation.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code associated with the response.
    /// </summary>
    [JsonIgnore]
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets a list of errors associated with the response.
    /// </summary>
    public List<string>? Errors { get; set; }

    /// <summary>
    /// Converts the response to an <see cref="ObjectResult"/>.
    /// </summary>
    /// <returns>An <see cref="ObjectResult"/> representing the response.</returns>
    public ObjectResult ToResult()
    {
        return new ObjectResult(this)
        {
            StatusCode = this.StatusCode
        };
    }

    /// <summary>
    /// Asynchronously converts the response to an <see cref="ObjectResult"/>.
    /// </summary>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, with an <see cref="ObjectResult"/> as the result.</returns>
    public async Task<ObjectResult> ToResultAsync()
    {
        return await Task.FromResult(new ObjectResult(this)
        {
            StatusCode = this.StatusCode
        });
    }
}
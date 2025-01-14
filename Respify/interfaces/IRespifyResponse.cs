using Microsoft.AspNetCore.Mvc;

namespace Respify.Interfaces;

/// <summary>
/// Interface for a standardized response object used in the Respify framework.
/// </summary>
/// <typeparam name="T">The type of the data being returned in the response.</typeparam>
public interface IRespifyResponse<T>
{
    /// <summary>
    /// Gets or sets the data being returned in the response.
    /// </summary>
    T? Data { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the response.
    /// </summary>
    string? Message { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the response indicates a successful operation.
    /// </summary>
    bool Success { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code associated with the response.
    /// </summary>
    int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets a list of errors associated with the response.
    /// </summary>
    List<string>? Errors { get; set; }

    /// <summary>
    /// Converts the response to an ObjectResult.
    /// </summary>
    /// <returns>An ObjectResult representing the response.</returns>
    ObjectResult ToResult();

    /// <summary>
    /// Asynchronously converts the response to an ObjectResult.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation, with an ObjectResult as the result.</returns>
    Task<ObjectResult> ToResultAsync();
}
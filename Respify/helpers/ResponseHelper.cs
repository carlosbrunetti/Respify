using Respify.Interfaces;

namespace Respify.helpers;

/// <summary>
/// Provides helper methods to generate standardized API responses.
/// </summary>
public static class ResponseHelper
{
    /// <summary>
    /// Generates a success response for paginated data.
    /// </summary>
    /// <typeparam name="T">The type of the data items.</typeparam>
    /// <param name="data">The paginated response data.</param>
    /// <param name="message">The success message.</param>
    /// <param name="statusCode">The HTTP status code (default is 200).</param>
    /// <returns>A standardized success response.</returns>
    public static RespifyResponse<IPaginatedResponse<T>> Success<T>(PaginatedResponse<T> data, string message, int statusCode = 200)
    {
        return new RespifyResponse<IPaginatedResponse<T>>(data, message, true, statusCode, null);
    }

    /// <summary>
    /// Generates a success response for non-paginated data.
    /// </summary>
    /// <typeparam name="T">The type of the data items.</typeparam>
    /// <param name="data">The non-paginated response data.</param>
    /// <param name="message">The success message.</param>
    /// <param name="statusCode">The HTTP status code (default is 200).</param>
    /// <returns>A standardized success response.</returns>
    public static RespifyResponse<INonPaginatedResponse<T>> Success<T>(NonPaginatedResponse<T> data, string message, int statusCode = 200)
    {
        return new RespifyResponse<INonPaginatedResponse<T>>(data, message, true, statusCode, null);
    }

    /// <summary>
    /// Creates a custom response.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    /// <param name="data">The response data.</param>
    /// <param name="message">The response message.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="success">Indicates if the response is successful.</param>
    /// <param name="errors">A list of errors (if any).</param>
    /// <returns>A standardized response.</returns>
    public static RespifyResponse<T> CreateResponse<T>(T? data, string? message, int statusCode, bool success, List<string>? errors)
    {
        return new RespifyResponse<T>(data, message, success, statusCode, errors);
    }

    /// <summary>
    /// Generates a failure response with optional data.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    /// <param name="data">The response data (optional).</param>
    /// <param name="message">The failure message.</param>
    /// <param name="statusCode">The HTTP status code (default is 400).</param>
    /// <returns>A standardized failure response.</returns>
    public static RespifyResponse<T> Failure<T>(T? data, string message, int statusCode = 400)
    {
        return new RespifyResponse<T>(data, message, false, statusCode);
    }

    /// <summary>
    /// Generates a failure response with optional data and a list of errors.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    /// <param name="data">The response data (optional).</param>
    /// <param name="message">The failure message.</param>
    /// <param name="errors">A list of errors.</param>
    /// <param name="statusCode">The HTTP status code (default is 400).</param>
    /// <returns>A standardized failure response.</returns>
    public static RespifyResponse<T> Failure<T>(T? data, string message, List<string> errors, int statusCode = 400)
    {
        return new RespifyResponse<T>(data, message, false, statusCode, errors);
    }
}
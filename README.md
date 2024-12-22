# Respify

Respify is a C# library designed to standardize API responses. It provides a consistent structure for both paginated and non-paginated data, making it easier to handle API responses in a uniform way.

## Installation

To install Respify, you can add it to your project via NuGet Package Manager:

```sh
dotnet add package Respify
```

## Generating Success Responses

You can generate success responses for both paginated and non-paginated return object using the `ResponseHelper` class.

### Paginated Response

```csharp
using Respify;
using Respify.helpers;

var cars = new List<Car>();
var paginatedResponse = new PaginatedResponse<List<Car>>(Items: cars, Count: cars.Count, PageNumber: 1, PageSize: 15, OrderBy: "Make", SortBy: "desc");
var response = ResponseHelper.Success(Data: paginatedResponse, Message: "Success", StatusCode: 200);
```

### Non-Paginated Response

```csharp
using Respify;
using Respify.helpers;

var cars = new List<Car>();
var nonPaginatedResponse = new NonPaginatedResponse<List<Car>>(Items: cars, Count: cars.Count);
var response = ResponseHelper.Success(Data: nonPaginatedResponse, Message: "Success", StatusCode: 200);
```

## Generating Failure Responses

You can generate failure responses with optional return object and a list of errors.

```csharp
using Respify;
using Respify.helpers;

var response = ResponseHelper.Failure<object>(Data: null, Message: "Failure", StatusCode: 400);
```

Or

You also can generate failure responses with optional 'Message' with a list of errors.

```csharp
using Respify;
using Respify.helpers;

var errors = new List<string>();
var response = ResponseHelper.Failure<object>(Data: null, Message: null, StatusCode: 400, Errors: errors);
```

## Creating Custom Responses

You can create custom responses with specific object, message, status code, success flag, and errors.

```csharp
using Respify;
using Respify.helpers;

int id = 1;
var response = ResponseHelper.CreateResponse(Data: id, Message: "message", StatusCode: 201, Success: true, Errors: null);
```

Or

```csharp
var response = ResponseHelper.CreateResponse<object>(Data: null, Message: "message", StatusCode: 201, Success: true, Errors: null);


```

## Classes

### NonPaginatedData

Represents non-paginated data.

```csharp
public class NonPaginatedResponse<T> : INonPaginatedResponse<T>
{
    public NonPaginatedResponse(T items, int total)
    {
        Items = items;
        Count = total;
    }

    public T Items { get; set; }
    public int Count { get; set; }
}
```

### PaginatedData

Represents paginated data.

```csharp
public class PaginatedResponse<T>: IPaginatedResponse<T>
{
    public PaginatedResponse(T items, int total, int page, int pageSize, string orderBy, string sort)
    {
        Items = items;
        Count = total;
        PageNumber = page;
        PageSize = pageSize;
        OrderBy = orderBy;
        SortBy = sort;
    }

    public T Items { get; set; }
    public int Count { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string OrderBy { get; set; }
    public string SortBy { get; set; }
}
```
### RespifyResponse<T>

Represents a standardized API response.

### ResponseHelper

```csharp
public class RespifyResponse<T> : IRespifyResponse<T>
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
```

Provides helper methods to generate standardized API responses.

```csharp
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
```

## License

This project is licensed under the MIT License.

This `README.md` file provides an overview of the Respify library, installation instructions, usage examples, and class definitions.
Respify is a C# library designed to standardize API responses. It provides a consistent structure for both paginated and non-paginated data, making it easier to handle API responses in a uniform way.

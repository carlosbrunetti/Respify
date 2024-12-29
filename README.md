<p align="center">
    <img src="images/respify.jpeg" alt="Project Logo" width="400" height="400">
</p>

# Respify

Respify is a C# library designed to standardize API responses. It provides a consistent structure for both paginated and non-paginated data, making it easier to handle API responses in a uniform way.

[![NuGet](https://img.shields.io/nuget/v/Respify.svg)](https://www.nuget.org/packages/Respify/)
[![NuGet](https://img.shields.io/nuget/dt/Respify.svg)](https://www.nuget.org/packages/Respify/)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=carlosbrunetti_Respify&metric=alert_status)](https://sonarcloud.io/dashboard?id=carlosbrunetti_Respify)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=carlosbrunetti_Respify&metric=coverage)](https://sonarcloud.io/dashboard?id=carlosbrunetti_Respify)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=carlosbrunetti_Respify&metric=bugs)](https://sonarcloud.io/dashboard?id=carlosbrunetti_Respify)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=carlosbrunetti_Respify&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=carlosbrunetti_Respify)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=carlosbrunetti_Respify&metric=code_smells)](https://sonarcloud.io/dashboard?id=carlosbrunetti_Respify)

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
## Converting Response to ObjectResult
Using ToResult() and ToResultAsync() methods, you can convert the response to an ObjectResult.

```csharp
var response = new RespifyResponse<string>("data", "Operation successful", true, 200);
var result = response.ToResult();
```
### Asynchronous Response Conversion
```csharp
var response = new RespifyResponse<string>("data", "Operation successful", true, 200);
var result = await response.ToResultAsync();
```

## Json Output

### Paginated Response

```json
{
    "data": {
        "items": [],
        "count": 0,
        "pageNumber": 1,
        "pageSize": 15,
        "orderBy": "Make",
        "sortBy": "desc"
    },
    "message": "Success",
    "success": true,
    "errors": null
}

```

### Non-Paginated Response

```json
{
    "data": {
        "items": [],
        "count": 0
    },
    "message": "Success",
    "success": true,
    "errors": null
}
```

### Custom Response

```json
{
  "data": 1,
  "message": "Created",
  "success": true,
  "errors": null
}
```
### Failure Response

```json
{
  "data": null,
  "message": "",
  "success": false,
  "errors": ["Error 1", "Error 2"]
}
```

## Classes

### NonPaginatedData

Represents non-paginated data.

```csharp
/// <summary>
/// Represents a non-paginated response.
/// </summary>
/// <typeparam name="T">The type of the items in the response.</typeparam>
public class NonPaginatedResponse<T> : INonPaginatedResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NonPaginatedResponse{T}"/> class.
    /// </summary>
    /// <param name="items">The items in the response.</param>
    /// <param name="total">The total count of items in the response.</param>
    public NonPaginatedResponse(T items, int total) => (Items, Count) = (items, total);
    
    /// <summary>
    /// Gets or sets the items in the response.
    /// </summary>
    public T Items { get; set; }

    /// <summary>
    /// Gets or sets the count of items in the response.
    /// </summary>
    public int Count { get; set; }
}
```

### PaginatedData

Represents paginated data.

```csharp
/// <summary>
/// Represents a paginated response.
/// </summary>
/// <typeparam name="T">The type of the items in the response.</typeparam>
public class PaginatedResponse<T> : IPaginatedResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class.
    /// </summary>
    /// <param name="items">The items in the response.</param>
    /// <param name="total">The total count of items in the response.</param>
    /// <param name="page">The current page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="orderBy">The field by which the items are ordered.</param>
    /// <param name="sort">The field by which the items are sorted.</param>
    public PaginatedResponse(T items, int total, int page, int pageSize, string orderBy, string sort)
    {
        Items = items;
        Count = total;
        PageNumber = page;
        PageSize = pageSize;
        OrderBy = orderBy;
        SortBy = sort;
    }

    /// <summary>
    /// Gets or sets the items in the response.
    /// </summary>
    public T Items { get; set; }

    /// <summary>
    /// Gets or sets the count of items in the response.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the size of the page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the field by which the items are ordered.
    /// </summary>
    public string OrderBy { get; set; }

    /// <summary>
    /// Gets or sets the field by which the items are sorted.
    /// </summary>
    public string SortBy { get; set; }
}
```
### RespifyResponse<T>

Represents a standardized API response.

```csharp
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
```
### ResponseHelper
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

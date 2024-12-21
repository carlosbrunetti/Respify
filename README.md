# Respify

Respify is a C# library designed to standardize API responses. It provides a consistent structure for both paginated and non-paginated data, making it easier to handle API responses in a uniform way.

## Installation

To install Respify, you can add it to your project via NuGet Package Manager:

```sh
dotnet add package Respify

Usage
Non-Paginated Data
To use non-paginated data, you can create an instance of NonPaginatedData<T> and use the ResponseHelper to generate a success response.

using Respify;
using Respify.helpers;

var data = new NonPaginatedData<string>
{
    Items = "Sample Item",
    Total = 1
};

var response = ResponseHelper.Success(data, "Request successful");

Paginated Data
For paginated data, create an instance of PaginatedData<T> and use the ResponseHelper to generate a success response.

using Respify;
using Respify.helpers;

var data = new PaginatedData<string>
{
    Items = new List<string> { "Item1", "Item2" },
    Total = 2,
    Page = 1,
    Size = 10,
    OrderBy = "Name",
    Sort = "asc"
};

var response = ResponseHelper.Success(data, "Request successful");

Failure Response
To generate a failure response, use the ResponseHelper.Failure method.

using Respify;
using Respify.helpers;

var errors = new List<string> { "Error 1", "Error 2" };
var response = ResponseHelper.Failure<string>(null, "Request failed", errors);

Classes
NonPaginatedData
Represents non-paginated data.

public class NonPaginatedData<T>
{
    public T Items { get; set; }
    public int Total { get; set; }
}

PaginatedData
Represents paginated data.

public class PaginatedData<T>
{
    public T Items { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public string OrderBy { get; set; }
    public string Sort { get; set; }
}

ResponseHelper
Provides helper methods to generate standardized API responses.

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

    public static RespifyResponse<T> Failure<T>(T? data, string message, List<string> errors, int statusCode = 400)
    {
        return new RespifyResponse<T>(data, message, false, statusCode, errors);
    }
}

License
This project is licensed under the MIT License.
This `README.md` file provides an overview of the Respify library, installation instructions, usage examples, and class definitions.

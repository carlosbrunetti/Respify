using Bogus;
using Respify;
using Respify.helpers;
using Tests.helpers.@class;
using Tests.helpers.generator;

namespace Tests;

public class ResponseHelperTests
{
    [Fact]
    public void Success_PaginatedResponse_ReturnsSuccessResponse()
    {
        var cars = new CarGenerator().GenerateCarList(10);
        var paginatedResponse = new PaginatedResponse<List<Car>>(cars, cars.Count, 1, 10, "Id", "asc");
        var result = ResponseHelper.Success(paginatedResponse, "Success");

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Success", result.Message);
        Assert.Equal(paginatedResponse, result.Data);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void Success_NonPaginatedResponse_ReturnsSuccessResponse()
    {
        var cars = new CarGenerator().GenerateCarList(10);
        var nonPaginatedResponse = new NonPaginatedResponse<List<Car>>(cars, cars.Count);
        var result = ResponseHelper.Success(nonPaginatedResponse, "Success");

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Success", result.Message);
        Assert.Equal(nonPaginatedResponse, result.Data);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void CreateResponse_WithNullMessage_ReturnsResponseWithNullMessage()
    {
        var car = new CarGenerator().GenerateCar();
        var result = ResponseHelper.CreateResponse(car, null, 201, true,null);

        Assert.True(result.Success);
        Assert.Equal(201, result.StatusCode);
        Assert.Null(result.Message);
        Assert.True(result.Errors == null);
    }
    
    [Fact]
    public void CreateResponse_WithNullData_ReturnsResponseWithNullData()
    {
        var result = ResponseHelper.CreateResponse<Car>(null, "Success", 201, true,null);

        Assert.Null(result.Data);
        Assert.True(result.Success);
        Assert.Equal(201, result.StatusCode);
        Assert.Equal("Success", result.Message);
        Assert.True(result.Errors == null);
    }

    [Fact]
    public void Failure_WithCustomStatusCode_ReturnsFailureResponse()
    {
        var data = new Faker().Lorem.Sentence();
        var result = ResponseHelper.Failure(data, "Failure");

        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Failure", result.Message);
        Assert.Equal(data, result.Data);
        Assert.False(result.Errors is { Count: > 0 });
    }

    [Fact]
    public void Failure_WithDataAndCustomStatusCodeAndErrors_ReturnsFailureResponse()
    {
        var errors = new Faker<string>().CustomInstantiator(x => x.Lorem.Sentence()).Generate(10);
        var result = ResponseHelper.Failure<object>(null,"Failure",errors,500);

        Assert.False(result.Success);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("Failure", result.Message);
        Assert.True(result.Errors is { Count: > 0 });
    }
    
    [Fact]
    public void Failure_WithNoMessageWithErrors_ReturnsFailureResponse()
    {
        var errors = new Faker<string>().CustomInstantiator(x => x.Lorem.Sentence()).Generate(10);
        var result = ResponseHelper.Failure<object>(null,null,errors);

        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);
        Assert.Null(result.Message);
        Assert.True(result.Errors is { Count: > 0 });
    }
}
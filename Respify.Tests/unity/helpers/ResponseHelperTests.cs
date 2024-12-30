using Bogus;
using Respify.helpers;
using Respify.Tests.helpers.@class;
using Respify.Tests.helpers.generator;

namespace Respify.Tests.unity.helpers;

public class ResponseHelperTests
{
    [Fact]
    public void Success_PaginatedResponse_ReturnsSuccessResponse()
    {
        var cars = new CarGenerator().GenerateCarList(10);
        var response = new PaginatedResponse<List<Car>>(cars, cars.Count(), 1, 10, "year", "asc");
        var result = ResponseHelper.Success(response, "Success");

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Success", result.Message);
        Assert.Equal(response, result.Data);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void Success_NonPaginatedResponse_ReturnsSuccessResponse()
    {
        var cars = new CarGenerator().GenerateCarList(10);
        var response = new NonPaginatedResponse<List<Car>>(cars, cars.Count);
        var result = ResponseHelper.Success(response, "Success");

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("Success", result.Message);
        Assert.Equal(response, result.Data);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void CreateResponse_WithNullMessage_ReturnsResponseWithNullMessage()
    {
        var car = new CarGenerator().GenerateCar();
        var response = ResponseHelper.CreateResponse(car, null, 201, true,null);

        Assert.True(response.Success);
        Assert.Equal(201, response.StatusCode);
        Assert.Null(response.Message);
        Assert.True(response.Errors == null);
    }
    
    [Fact]
    public void CreateResponse_WithNullData_ReturnsResponseWithNullData()
    {
        var response = ResponseHelper.CreateResponse<Car>(null, "Success", 201, true,null);

        Assert.Null(response.Data);
        Assert.True(response.Success);
        Assert.Equal(201, response.StatusCode);
        Assert.Equal("Success", response.Message);
        Assert.True(response.Errors == null);
    }

    [Fact]
    public void Failure_WithCustomStatusCode_ReturnsFailureResponse()
    {
        var data = new Faker().Lorem.Sentence();
        var response = ResponseHelper.Failure(data, "Failure");

        Assert.False(response.Success);
        Assert.Equal(400, response.StatusCode);
        Assert.Equal("Failure", response.Message);
        Assert.Equal(data, response.Data);
        Assert.False(response.Errors is { Count: > 0 });
    }

    [Fact]
    public void Failure_WithDataAndCustomStatusCodeAndErrors_ReturnsFailureResponse()
    {
        var errors = new Faker<string>().CustomInstantiator(x => x.Lorem.Sentence()).Generate(10);
        var response = ResponseHelper.Failure<object>(null,"Failure",errors,500);

        Assert.False(response.Success);
        Assert.Equal(500, response.StatusCode);
        Assert.Equal("Failure", response.Message);
        Assert.True(response.Errors is { Count: > 0 });
    }
    
    [Fact]
    public void Failure_WithNoMessageWithErrors_ReturnsFailureResponse()
    {
        var errors = new Faker<string>().CustomInstantiator(x => x.Lorem.Sentence()).Generate(10);
        var response = ResponseHelper.Failure<object>(null,null,errors);

        Assert.False(response.Success);
        Assert.Equal(400, response.StatusCode);
        Assert.Null(response.Message);
        Assert.True(response.Errors is { Count: > 0 });
    }
}
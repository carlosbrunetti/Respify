using Microsoft.AspNetCore.Mvc;

namespace Respify.Tests.unity.classes;

public class RespifyResponseTests
{
    #region Properties

    [Fact]
    public void DataProperty_CanBeSetAndRetrieved()
    {
        var response = new RespifyResponse<string>("data", "message", true, 200);
        Assert.Equal("data", response.Data);
    }

    [Fact]
    public void MessageProperty_CanBeSetAndRetrieved()
    {
        var response = new RespifyResponse<string>("data", "message", true, 200);
        Assert.Equal("message", response.Message);
    }

    [Fact]
    public void SuccessProperty_CanBeSetAndRetrieved()
    {
        var response = new RespifyResponse<string>("data", "message", true, 200);
        Assert.True(response.Success);
    }

    [Fact]
    public void StatusCodeProperty_CanBeSetAndRetrieved()
    {
        var response = new RespifyResponse<string>("data", "message", true, 200);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public void ErrorsProperty_CanBeSetAndRetrieved()
    {
        var errors = new List<string> { "Error1", "Error2" };
        var response = new RespifyResponse<string>("data", "message", false, 400, errors);
        Assert.Equal(errors, response.Errors);
    }

    [Fact]
    public void DataProperty_CanBeSetToNull()
    {
        var response = new RespifyResponse<string>(null, "message", true, 200);
        Assert.Null(response.Data);
    }

    [Fact]
    public void MessageProperty_CanBeSetToNull()
    {
        var response = new RespifyResponse<string>("data", null, true, 200);
        Assert.Null(response.Message);
    }

    [Fact]
    public void ErrorsProperty_CanBeSetToNull()
    {
        var response = new RespifyResponse<string>("data", "message", false, 400, null);
        Assert.Null(response.Errors);
    }

    #endregion
    
    #region ToResult

    [Fact]
    public void ToResult_ReturnsObjectResultWithCorrectStatusCode()
    {
        var response = new RespifyResponse<string>("data", "message", true, 200);
        var result = response.ToResult();
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void ToResult_ReturnsObjectResultWithNullData()
    {
        var response = new RespifyResponse<string>(null, "message", true, 200);
        var result = response.ToResult();
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void ToResult_ReturnsObjectResultWithErrors()
    {
        var errors = new List<string> { "Error1", "Error2" };
        var response = new RespifyResponse<string>(null, "message", false, 400, errors);
        var result = response.ToResult();
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal(errors, ((RespifyResponse<string>)result.Value).Errors);
    }

    [Fact]
    public void ToResult_ReturnsObjectResultWithEmptyStringData()
    {
        var response = new RespifyResponse<string>("", "message", true, 200);
        var result = response.ToResult();
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("", ((RespifyResponse<string>)result.Value).Data);
    }

    [Fact]
    public void ToResult_ReturnsObjectResultWithNullMessage()
    {
        var response = new RespifyResponse<string>("data", null, true, 200);
        var result = response.ToResult();
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(((RespifyResponse<string>)result.Value).Message);
    }

    [Fact]
    public void ToResult_ReturnsObjectResultWithEmptyErrorsList()
    {
        var response = new RespifyResponse<string>("data", "message", false, 400, new List<string>());
        var result = response.ToResult();
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Empty(((RespifyResponse<string>)result.Value).Errors);
    }

    #endregion

    #region ToResultAsync

    [Fact]
    public async Task ToResultAsync_ReturnsObjectResultWithCorrectStatusCode()
    {
        // Arrange
        var response = new RespifyResponse<string>("data", "message", true, 200);

        // Act
        var result = await response.ToResultAsync();

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task ToResultAsync_ReturnsObjectResultWithNullData()
    {
        // Arrange
        var response = new RespifyResponse<string>(null, "message", true, 200);

        // Act
        var result = await response.ToResultAsync();

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task ToResultAsync_ReturnsObjectResultWithErrors()
    {
        // Arrange
        var errors = new List<string> { "Error1", "Error2" };
        var response = new RespifyResponse<string>(null, "message", false, 400, errors);

        // Act
        var result = await response.ToResultAsync();

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal(errors, ((RespifyResponse<string>)result.Value).Errors);
    }

    [Fact]
    public async Task ToResultAsync_ReturnsObjectResultWithEmptyStringData()
    {
        // Arrange
        var response = new RespifyResponse<string>("", "message", true, 200);

        // Act
        var result = await response.ToResultAsync();

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal("", ((RespifyResponse<string>)result.Value).Data);
    }


    [Fact]
    public async Task ToResultAsync_ReturnsObjectResultWithNullMessage()
    {
        // Arrange
        var response = new RespifyResponse<string>("data", null, true, 200);

        // Act
        var result = await response.ToResultAsync();

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(((RespifyResponse<string>)result.Value).Message);
    }

    [Fact]
    public async Task ToResultAsync_ReturnsObjectResultWithEmptyErrorsList()
    {
        // Arrange
        var response = new RespifyResponse<string>("data", "message", false, 400, new List<string>());

        // Act
        var result = await response.ToResultAsync();

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Empty(((RespifyResponse<string>)result.Value).Errors);
    }

    #endregion
}
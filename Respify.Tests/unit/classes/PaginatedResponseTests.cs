using Respify.Tests.helpers.@class;
using Respify.Tests.helpers.generator;

namespace Respify.Tests.unit.classes
{
    public class PaginatedResponseTests
    {
        [Fact]
        public void GetProperties_ShouldReturnCorrectValues()
        {
            // Arrange
            var cars = new CarGenerator().GenerateCarList(10);
            var response = new PaginatedResponse<List<Car>>(cars, cars.Count(), 1, 10, "year", "asc");

            // Act & Assert
            Assert.Equal(cars, response.Items);
            Assert.Equal(10, response.Count);
            Assert.Equal(1, response.PageNumber);
            Assert.Equal(10, response.PageSize);
            Assert.Equal("year", response.OrderBy);
            Assert.Equal("asc", response.SortBy);
        }
    }
}
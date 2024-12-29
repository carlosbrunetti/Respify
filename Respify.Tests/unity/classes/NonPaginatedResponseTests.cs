using Respify.Tests.helpers.@class;
using Respify.Tests.helpers.generator;

namespace Respify.Tests.unity.classes
{
    public class NonPaginatedResponseTests
    {
        [Fact]
        public void GetProperties_ShouldReturnCorrectValues()
        {
            // Arrange
            var cars = new CarGenerator().GenerateCarList(10);
            var response = new NonPaginatedResponse<List<Car>>(cars, cars.Count);
                
            // Act & Assert
            Assert.Equal(cars, response.Items);
            Assert.Equal(10, response.Count);
        }
    }
}
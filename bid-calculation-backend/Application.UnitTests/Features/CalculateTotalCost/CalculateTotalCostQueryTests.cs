using Application.Features.CalculateTotalCost;
using Domain.Vehicles.Enums;
using Xunit;

namespace Application.UnitTests.Features.CalculateTotalCost;

public class CalculateTotalCostQueryTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        const decimal price = 1000m;
        var vehicleType = VehicleType.Common;

        // Act
        var query = new CalculateTotalCostQuery(price, vehicleType);

        // Assert
        Assert.Equal(price, query.Price);
        Assert.Equal(vehicleType, query.VehicleType);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(0.01)]
    public void Price_AcceptsValidValues(decimal price)
    {
        // Arrange & Act
        var query = new CalculateTotalCostQuery(price, VehicleType.Luxury);

        // Assert
        Assert.Equal(price, query.Price);
    }

    [Theory]
    [InlineData(VehicleType.Common)]
    [InlineData(VehicleType.Luxury)]
    public void VehicleType_AcceptsAllEnumValues(VehicleType vehicleType)
    {
        // Arrange & Act
        var query = new CalculateTotalCostQuery(1000, vehicleType);

        // Assert
        Assert.Equal(vehicleType, query.VehicleType);
    }
}
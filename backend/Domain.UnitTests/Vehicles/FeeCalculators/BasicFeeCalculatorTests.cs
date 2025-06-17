using Domain.Vehicles.Enums;
using Domain.Vehicles.Exeptions;
using Domain.Vehicles.FeeCalculators;
using FluentAssertions;

namespace Domain.UnitTests.Vehicles.FeeCalculators;

public class BasicFeeCalculatorTests
{
    private readonly BasicFeeCalculator _calculator = new();

    [Theory]
    [InlineData(398.00, VehicleType.Common, 39.80)]    // Caso normal
    [InlineData(501.00, VehicleType.Common, 50.00)]    // Máximo Common
    [InlineData(57.00, VehicleType.Common, 10.00)]     // Mínimo Common
    [InlineData(1800.00, VehicleType.Luxury, 180.00)]  // Caso normal Luxury
    [InlineData(1100.00, VehicleType.Common, 50.00)]   // Máximo Common
    [InlineData(1000000.00, VehicleType.Luxury, 200.00)] // Máximo Luxury
    [InlineData(100.00, VehicleType.Luxury, 25.00)]    // Mínimo Luxury
    public void Calculate_Returns_CorrectValues(
        decimal price,
        VehicleType type,
        decimal expected)
    {
        // Act
        var result = _calculator.Calculate(price, type);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Calculate_ThrowsException_ForInvalidPrice()
    {
        // Arrange
        var invalidPrice = -100m;

        // Act & Assert
        Assert.Throws<InvalidPriceException>(() =>
            _calculator.Calculate(invalidPrice, VehicleType.Common));
    }

}
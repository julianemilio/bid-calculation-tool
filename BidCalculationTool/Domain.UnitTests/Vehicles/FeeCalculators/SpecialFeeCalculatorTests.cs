using Domain.Vehicles.Enums;
using Domain.Vehicles.FeeCalculators;
using FluentAssertions;

namespace Domain.UnitTests.Vehicles.FeeCalculators;

public class SpecialFeeCalculatorTests
{
    private readonly SpecialFeeCalculator _calculator = new();

    [Theory]
    [InlineData(398.00, VehicleType.Common, 7.96)]     // 2% de 398
    [InlineData(501.00, VehicleType.Common, 10.02)]    // 2% de 501
    [InlineData(57.00, VehicleType.Common, 1.14)]      // 2% de 57
    [InlineData(1800.00, VehicleType.Luxury, 72.00)]   // 4% de 1800
    [InlineData(1100.00, VehicleType.Common, 22.00)]   // 2% de 1100
    [InlineData(1000000.00, VehicleType.Luxury, 40000.00)] // 4% de 1,000,000
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
}
using Domain.Vehicles.FeeCalculators;
using FluentAssertions;

namespace Domain.UnitTests.Vehicles.FeeCalculators;

public class AssociationFeeCalculatorTests
{
    private readonly AssociationFeeCalculator _calculator = new();

    [Theory]
    [InlineData(398.00, 5.00)]    // $1-500
    [InlineData(500.00, 5.00)]     // Límite inferior
    [InlineData(501.00, 10.00)]    // $501-1000
    [InlineData(1000.00, 10.00)]   // Límite inferior
    [InlineData(1001.00, 15.00)]   // $1001-3000
    [InlineData(1800.00, 15.00)]   // Dentro de rango
    [InlineData(3000.00, 15.00)]   // Límite inferior
    [InlineData(3001.00, 20.00)]   // >$3000
    [InlineData(1100.00, 15.00)]   // $1001-3000
    [InlineData(1000000.00, 20.00)] // >$3000
    public void Calculate_Returns_CorrectValues(
        decimal price,
        decimal expected)
    {
        // Act
        var result = _calculator.Calculate(price);

        // Assert
        result.Should().Be(expected);
    }
}
using Domain.Vehicles.FeeCalculators;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Vehicles.FeeCalculators;

public class StorageFeeTests
{
    private readonly StorageFee _calculator = new();

    [Fact]
    public void Calculate_Always_Returns100()
    {
        // Act
        var result = _calculator.Calculate();

        // Assert
        result.Should().Be(100.00m);
    }
}
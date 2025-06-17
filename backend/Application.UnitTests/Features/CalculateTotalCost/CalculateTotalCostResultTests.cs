using Application.Features.CalculateTotalCost;
using Xunit;

namespace Application.UnitTests.Features.CalculateTotalCost;

public class CalculateTotalCostResultTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        const decimal basicFee = 50m;
        const decimal specialFee = 20m;
        const decimal associationFee = 10m;
        const decimal storageFee = 100m;
        const decimal total = 1180m;

        // Act
        var result = new CalculateTotalCostResult(
            basicFee, specialFee, associationFee, storageFee, total);

        // Assert
        Assert.Equal(basicFee, result.BasicFee);
        Assert.Equal(specialFee, result.SpecialFee);
        Assert.Equal(associationFee, result.AssociationFee);
        Assert.Equal(storageFee, result.StorageFee);
        Assert.Equal(total, result.Total);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(10.50, 5.25, 3.75, 100.00, 119.50)]
    [InlineData(200.00, 40000.00, 20.00, 100.00, 40320.00)]
    public void Properties_HandleVariousValues(
        decimal basicFee,
        decimal specialFee,
        decimal associationFee,
        decimal storageFee,
        decimal total)
    {
        // Arrange & Act
        var result = new CalculateTotalCostResult(
            basicFee, specialFee, associationFee, storageFee, total);

        // Assert
        Assert.Equal(basicFee, result.BasicFee);
        Assert.Equal(specialFee, result.SpecialFee);
        Assert.Equal(associationFee, result.AssociationFee);
        Assert.Equal(storageFee, result.StorageFee);
        Assert.Equal(total, result.Total);
    }
}
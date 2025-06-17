
using Application.Features.CalculateTotalCost;
using Domain.Vehicles.Enums;
using Domain.Vehicles.Exeptions;
using Domain.Vehicles.FeeCalculators;
using Moq;
using Xunit;

namespace Application.UnitTests.Features.CalculateTotalCost;

public class CalculateTotalCostQueryHandlerTests
{
    private readonly CalculateTotalCostQueryHandler _handler;
    private readonly Mock<BasicFeeCalculator> _basicFeeCalculatorMock;
    private readonly Mock<SpecialFeeCalculator> _specialFeeCalculatorMock;
    private readonly Mock<AssociationFeeCalculator> _associationFeeCalculatorMock;
    private readonly Mock<StorageFee> _storageFeeMock;

    public CalculateTotalCostQueryHandlerTests()
    {
        _basicFeeCalculatorMock = new Mock<BasicFeeCalculator>();
        _specialFeeCalculatorMock = new Mock<SpecialFeeCalculator>();
        _associationFeeCalculatorMock = new Mock<AssociationFeeCalculator>();
        _storageFeeMock = new Mock<StorageFee>();

        _handler = new CalculateTotalCostQueryHandler(
            _basicFeeCalculatorMock.Object,
            _specialFeeCalculatorMock.Object,
            _associationFeeCalculatorMock.Object,
            _storageFeeMock.Object);
    }

    [Theory]
    [InlineData(398.00, VehicleType.Common, 39.80, 7.96, 5.00, 100.00, 550.76)]
    [InlineData(501.00, VehicleType.Common, 50.00, 10.02, 10.00, 100.00, 671.02)]
    [InlineData(57.00, VehicleType.Common, 10.00, 1.14, 5.00, 100.00, 173.14)]
    [InlineData(1800.00, VehicleType.Luxury, 180.00, 72.00, 15.00, 100.00, 2167.00)]
    [InlineData(1100.00, VehicleType.Common, 50.00, 22.00, 15.00, 100.00, 1287.00)]
    [InlineData(1000000.00, VehicleType.Luxury, 200.00, 40000.00, 20.00, 100.00, 1040320.00)]
    public void Handle_ReturnsCorrectResult(
        decimal price,
        VehicleType vehicleType,
        decimal basicFee,
        decimal specialFee,
        decimal associationFee,
        decimal storageFee,
        decimal total)
    {
        // Arrange
        var query = new CalculateTotalCostQuery(price, vehicleType);

        _basicFeeCalculatorMock.Setup(x => x.Calculate(price, vehicleType))
            .Returns(basicFee);

        _specialFeeCalculatorMock.Setup(x => x.Calculate(price, vehicleType))
            .Returns(specialFee);

        _associationFeeCalculatorMock.Setup(x => x.Calculate(price))
            .Returns(associationFee);

        _storageFeeMock.Setup(x => x.Calculate())
            .Returns(storageFee);

        // Act
        var result = _handler.Handle(query);

        // Assert
        Assert.Equal(basicFee, result.BasicFee);
        Assert.Equal(specialFee, result.SpecialFee);
        Assert.Equal(associationFee, result.AssociationFee);
        Assert.Equal(storageFee, result.StorageFee);
        Assert.Equal(total, result.Total);
    }

    [Fact]
    public void Handle_ThrowsInvalidPriceException_ForPriceZero()
    {
        // Arrange
        var query = new CalculateTotalCostQuery(0, VehicleType.Common);

        // Act & Assert
        Assert.Throws<InvalidPriceException>(() => _handler.Handle(query));
    }

    [Fact]
    public void Handle_ThrowsInvalidPriceException_ForNegativePrice()
    {
        // Arrange
        var query = new CalculateTotalCostQuery(-100, VehicleType.Luxury);

        // Act & Assert
        Assert.Throws<InvalidPriceException>(() => _handler.Handle(query));
    }

    [Fact]
    public void Handle_UsesCorrectCalculators()
    {
        // Arrange
        var query = new CalculateTotalCostQuery(1000, VehicleType.Common);

        // Act
        _ = _handler.Handle(query);

        // Assert
        _basicFeeCalculatorMock.Verify(
            x => x.Calculate(1000, VehicleType.Common),
            Times.Once);

        _specialFeeCalculatorMock.Verify(
            x => x.Calculate(1000, VehicleType.Common),
            Times.Once);

        _associationFeeCalculatorMock.Verify(
            x => x.Calculate(1000),
            Times.Once);

        _storageFeeMock.Verify(
            x => x.Calculate(),
            Times.Once);
    }
}
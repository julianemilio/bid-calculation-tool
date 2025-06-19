using Application.Abstractions;
using Domain.Vehicles.Exeptions;
using Domain.Vehicles.FeeCalculators;

namespace Application.Features.CalculateTotalCost;

public class CalculateTotalCostQueryHandler
    : IQueryHandler<CalculateTotalCostQuery, CalculateTotalCostResult>
{
    private readonly BasicFeeCalculator _basicFeeCalculator;
    private readonly SpecialFeeCalculator _specialFeeCalculator;
    private readonly AssociationFeeCalculator _associationFeeCalculator;
    private readonly StorageFee _storageFee;

    public CalculateTotalCostQueryHandler(
        BasicFeeCalculator basicFeeCalculator,
        SpecialFeeCalculator specialFeeCalculator,
        AssociationFeeCalculator associationFeeCalculator,
        StorageFee storageFee)
    {
        _basicFeeCalculator = basicFeeCalculator;
        _specialFeeCalculator = specialFeeCalculator;
        _associationFeeCalculator = associationFeeCalculator;
        _storageFee = storageFee;
    }

    public CalculateTotalCostResult Handle(CalculateTotalCostQuery query)
    {
        if (query.Price <= 0) throw new InvalidPriceException();

        var basicFee = _basicFeeCalculator.Calculate(query.Price, query.VehicleType);
        var specialFee = _specialFeeCalculator.Calculate(query.Price, query.VehicleType);
        var associationFee = _associationFeeCalculator.Calculate(query.Price);
        var storageFee = _storageFee.Calculate();

        var total = query.Price + basicFee + specialFee + associationFee + storageFee;

        return new CalculateTotalCostResult(
            basicFee,
            specialFee,
            associationFee,
            storageFee,
            total
        );
    }
}
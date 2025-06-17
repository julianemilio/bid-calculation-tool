namespace Application.Features.CalculateTotalCost;

public class CalculateTotalCostResult
{
    public decimal BasicFee { get; }
    public decimal SpecialFee { get; }
    public decimal AssociationFee { get; }
    public decimal StorageFee { get; }
    public decimal Total { get; }

    public CalculateTotalCostResult(
        decimal basicFee,
        decimal specialFee,
        decimal associationFee,
        decimal storageFee,
        decimal total)
    {
        BasicFee = basicFee;
        SpecialFee = specialFee;
        AssociationFee = associationFee;
        StorageFee = storageFee;
        Total = total;
    }
}
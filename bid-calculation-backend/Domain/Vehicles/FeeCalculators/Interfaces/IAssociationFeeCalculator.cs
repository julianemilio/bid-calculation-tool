using Domain.Vehicles.Enums;

namespace Domain.Vehicles.FeeCalculators.Interfaces
{
    public interface IAssociationFeeCalculator
    {
        decimal Calculate(decimal price);
    }
}

using Domain.Vehicles.Enums;

namespace Domain.Vehicles.FeeCalculators.Interfaces
{
    public interface ISpecialFeeCalculator
    {
        decimal Calculate(decimal price, VehicleType vehicleType);
    }
}

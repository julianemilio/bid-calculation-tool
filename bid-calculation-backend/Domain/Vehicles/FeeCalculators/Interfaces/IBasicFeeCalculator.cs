using Domain.Vehicles.Enums;

namespace Domain.Vehicles.FeeCalculators.Interfaces
{
    public interface IBasicFeeCalculator
    {
        decimal Calculate(decimal price, VehicleType vehicleType);
    }
}

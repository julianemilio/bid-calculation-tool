using Domain.Vehicles.Enums;
using Domain.Vehicles.Exeptions;
using Domain.Vehicles.FeeCalculators.Interfaces;

namespace Domain.Vehicles.FeeCalculators
{
    public class BasicFeeCalculator : IBasicFeeCalculator
    {
        public decimal Calculate(decimal price, VehicleType vehicleType)
        {
            if (price <= 0) throw new InvalidPriceException();

            decimal percentage = 0.10m;
            decimal fee = price * percentage;

            return vehicleType switch
            {
                VehicleType.Common => Math.Clamp(fee, 10, 50),
                VehicleType.Luxury => Math.Clamp(fee, 25, 200),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }
}

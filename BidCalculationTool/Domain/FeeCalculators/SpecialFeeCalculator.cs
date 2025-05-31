using Domain.Enums;
using Domain.Exeptions;

namespace Domain.FeeCalculators
{
    public class SpecialFeeCalculator
    {
        public decimal Calculate(decimal price, VehicleType vehicleType)
        {
            if (price <= 0) throw new InvalidPriceException();

            return vehicleType switch
            {
                VehicleType.Common => price * 0.02m, // 2%
                VehicleType.Luxury => price * 0.04m, // 4%
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }
}

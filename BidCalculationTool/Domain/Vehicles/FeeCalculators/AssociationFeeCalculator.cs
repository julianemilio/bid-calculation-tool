using Domain.Vehicles.Exeptions;

namespace Domain.Vehicles.FeeCalculators
{
    public class AssociationFeeCalculator
    {
        public decimal Calculate(decimal price)
        {
            if (price <= 0) throw new InvalidPriceException();

            return price switch
            {
                <= 500 => 5,
                <= 1000 => 10,
                <= 3000 => 15,
                _ => 20
            };
        }
    }
}

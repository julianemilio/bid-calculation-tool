using Domain.Vehicles.Enums;

namespace Domain.Vehicles.FeeCalculators.Interfaces
{
    public interface IStorageFee
    {
        decimal Calculate();
    }
}

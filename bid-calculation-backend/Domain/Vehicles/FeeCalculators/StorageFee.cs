using Domain.Vehicles.FeeCalculators.Interfaces;

namespace Domain.Vehicles.FeeCalculators
{
    public class StorageFee: IStorageFee
    {
        public decimal Calculate() => 100; // Fixed fee
    }
}

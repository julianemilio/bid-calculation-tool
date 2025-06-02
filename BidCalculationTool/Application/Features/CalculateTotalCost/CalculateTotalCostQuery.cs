using Domain.Vehicles.Enums;

namespace Application.Features.CalculateTotalCost;

public class CalculateTotalCostQuery
{
    public decimal Price { get; }
    public VehicleType VehicleType { get; }

    public CalculateTotalCostQuery(decimal price, VehicleType vehicleType)
    {
        Price = price;
        VehicleType = vehicleType;
    }
}
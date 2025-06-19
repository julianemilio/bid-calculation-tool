using Application.Abstractions;
using Application.Features.CalculateTotalCost;
using Domain.Vehicles.FeeCalculators;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<BasicFeeCalculator>();
        services.AddScoped<SpecialFeeCalculator>();
        services.AddScoped<AssociationFeeCalculator>();
        services.AddScoped<StorageFee>();

        services.AddScoped<IQueryHandler<CalculateTotalCostQuery, CalculateTotalCostResult>,
            CalculateTotalCostQueryHandler>();

        return services;
    }
}
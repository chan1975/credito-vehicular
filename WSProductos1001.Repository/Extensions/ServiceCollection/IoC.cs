using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Repository;

namespace WSProductos1001.Repository.Extensions.ServiceCollection;

public static class IoC
{
    public static IServiceCollection AddDependencyRepository(this IServiceCollection services)
    {
        services.AddScoped<IPatioRepository, PatioRepository>();
        services.AddTransient<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IAgentRepository, AgentRepository>();
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Features.Agent;
using WSProductos1001.Domain.Features.Brand;
using WSProductos1001.Domain.Features.Client;
using WSProductos1001.Domain.Features.Patio;
using WSProductos1001.Domain.Features.Vehicle;
using WSProductos1001.Domain.Services;

namespace WSProductos1001.Domain.Extensions.ServicesCollection;

public static class IoC
{
    public static IServiceCollection AddDependencyDomain(this IServiceCollection services)
    {
        services.AddScoped<IPatioService, PatioService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IAgentService, AgentService>();
        services.AddScoped<IClientService, ClientService>();
        
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Repository;

namespace WSProductos1001.Repository.Extensions.ServiceCollection;

public static class IoC
{
    public static IServiceCollection AddDependencyRepository(this IServiceCollection services)
    {
        services.AddScoped<IPatioRepository, PatioRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IAgentRepository, AgentRepository>();
        services.AddScoped<ICatalogRepository, CatalogRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAssignClientRepository, AssignClientRepository>();
        services.AddScoped<IRequestCreditRepository, RequestCreditRepository>();
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Features.Patio;
using WSProductos1001.Domain.Services;

namespace WSProductos1001.Domain.Extensions.ServicesCollection;

public static class IoC
{
    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
        services.AddScoped<IPatioService, PatioService>();
        return services;
    }
}
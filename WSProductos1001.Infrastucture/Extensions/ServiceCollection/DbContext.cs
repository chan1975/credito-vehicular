using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Infrastucture.Extensions.ServiceCollection;

public static class DbContext
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CreditContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("creditoDb"));
            options.ConfigureWarnings(x => x.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning));
        });
        return services;
    }
}
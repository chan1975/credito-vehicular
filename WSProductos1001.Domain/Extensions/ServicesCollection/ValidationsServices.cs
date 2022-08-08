using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Features.Patio;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Extensions.ServicesCollection;

public static class ValidationsServices
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddTransient<IValidator<EPatio>, PatioValidator>();
        return services;
    }
}
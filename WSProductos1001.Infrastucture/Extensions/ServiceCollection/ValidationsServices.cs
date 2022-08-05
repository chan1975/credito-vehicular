using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Validators;

namespace WSProductos1001.Infrastucture.Extensions.ServiceCollection;

public static class ValidationsServices
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddTransient<IValidator<EPatio>, PatioValidator>();
        return services;
    }
}
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WSProductos1001.Domain.Features.Agent;
using WSProductos1001.Domain.Features.AssignClient;
using WSProductos1001.Domain.Features.Client;
using WSProductos1001.Domain.Features.Patio;
using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Domain.Features.Vehicle;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Extensions.ServicesCollection;

public static class ValidationsServices
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddTransient<IValidator<EPatio>, PatioValidator>();
        services.AddTransient<IValidator<EVehicle>, VehicleValidator>();
        services.AddTransient<IValidator<EAgent>, AgentValidator>();
        services.AddTransient<IValidator<EClient>, ClientValidator>();
        services.AddTransient<IValidator<EAssignClient>, ClientPatioValidator>();
        services.AddTransient<IValidator<ERequestCredit>, RequestCreditValidator>();
        return services;
    }
}
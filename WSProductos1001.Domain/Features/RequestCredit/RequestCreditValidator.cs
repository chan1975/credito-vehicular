using FluentValidation;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.RequestCredit;

public class RequestCreditValidator:AbstractValidator<ERequestCredit>
{
    public RequestCreditValidator()
    {
        RuleFor(x => x.BuildDate).NotEmpty().WithMessage("La fecha de elaboracion es obligatoria");
        RuleFor(x => x.ClientId)
            .NotEmpty().WithMessage("El cliente es obligatorio")
            .GreaterThanOrEqualTo(1).WithMessage("El cliente debe ser mayor a 0");
        RuleFor(x => x.PatioId)
            .NotEmpty().WithMessage("El patio es obligatorio")
            .GreaterThanOrEqualTo(1).WithMessage("El patio debe ser mayor a 0");
        RuleFor(x => x.VehicleId)
            .NotEmpty().WithMessage("El vehiculo es obligatorio")
            .GreaterThanOrEqualTo(1).WithMessage("El vehiculo debe ser mayor a 0");
        RuleFor(x => x.TermMonth)
            .NotEmpty().WithMessage("Los meses de plazo son obligatorios")
            .GreaterThanOrEqualTo(0).WithMessage("Los meses de plazo deben ser positivos");
        RuleFor(x => x.Fee)
            .NotEmpty().WithMessage("El valor de la cuota es obligatorio")
            .GreaterThanOrEqualTo(0).WithMessage("El valor de la cuota debe ser positivo");
        RuleFor(x => x.AgentId)
            .NotEmpty().WithMessage("El agente es obligatorio")
            .GreaterThanOrEqualTo(1).WithMessage("El agente debe ser mayor a 0");
        RuleFor(x => x.Entry)
            .NotEmpty().WithMessage("La entrada es obligatoria")
            .GreaterThanOrEqualTo(0).WithMessage("La entrada debe ser positiva");
        
    }
}
using FluentValidation;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Patio;

public class PatioValidator:AbstractValidator<EPatio>
{
    public PatioValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("El nombre es requerido");
        RuleFor(p => p.Address).NotEmpty().WithMessage("La direccion es requerida");
        RuleFor(p => p.Phone).NotEmpty().WithMessage("El telefono es requerido");
        RuleFor(p => p.NumberSalePoint)
            .NotNull().WithMessage("El numero de punto de venta es requerido")
            .GreaterThan(0).WithMessage("El numero de punto de venta debe ser mayor a 0");
        
        
    }
}
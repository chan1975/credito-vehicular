using FluentValidation;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Agent;

public class AgentValidator: AbstractValidator<EAgent>
{
    public AgentValidator()
    {
        RuleFor(x => x.Address).NotEmpty().WithMessage("Direccion no puede ser nulo");
        RuleFor(x => x.Names).NotEmpty().WithMessage("Nombres no puede ser nulo");
        RuleFor(x => x.LastNames).NotEmpty().WithMessage("Apellidos no puede ser nulo");
        RuleFor(x => x.Age).NotEmpty().WithMessage("Edad no puede ser nulo");
        RuleFor(x => x.Identification).NotEmpty().WithMessage("Identificacion no puede ser nulo");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefono no puede ser nulo");
        RuleFor(x => x.CellPhone).NotEmpty().WithMessage("Celular no puede ser nulo");
        RuleFor(x => x.PatioId).NotEmpty().WithMessage("Patio no puede ser nulo");

    }
    
}
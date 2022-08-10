using FluentValidation;

namespace WSProductos1001.Domain.Features.AssignClient;

public class ClientPatioValidator: AbstractValidator<Entities.AssignClient>
{
    public ClientPatioValidator()
    {
        RuleFor(x => x.ClientId).GreaterThanOrEqualTo(1).WithMessage("Cliente inválido");
        RuleFor(x => x.PatioId).GreaterThanOrEqualTo(1).WithMessage("Patio inválido");
        RuleFor(x=>x.AssignDate).NotEmpty().WithMessage("Fecha Asugnacion es obligatoria");
    }
}
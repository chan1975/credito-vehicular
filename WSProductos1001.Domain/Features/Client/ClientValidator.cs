using FluentValidation;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Client;

public class ClientValidator: AbstractValidator<EClient>
{
    public ClientValidator()
    {
        //all fields of EClient are required
        RuleFor(x => x.Identification).NotEmpty().WithMessage("Indenftificacion es obligatoria");
        RuleFor(x => x.Names).NotEmpty().WithMessage("Nombre es obligatorio");
        RuleFor(x => x.LastNames).NotEmpty().WithMessage("Apellido es obligatorio");
        RuleFor(x => x.BirthDay).NotEmpty().WithMessage("Fecha Nacimiento es obligatoria");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Direccion es obligatoria");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefono es obligatorio");
        RuleFor(x => x.MaritalStatus).NotEmpty().WithMessage("Estado Civil es obligatorio");
        RuleFor(x => x.SpouseIdentification).NotEmpty().WithMessage("Identificacion Conyuge es obligatorio");
        RuleFor(x => x.SpouseName).NotEmpty().WithMessage("Nombre Conyuge es obligatorio");
        RuleFor(x => x.SubjectCredit).NotEmpty().WithMessage("Subjetivo Credito es obligatorio");
        
    }
    
}
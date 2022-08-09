using FluentValidation;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Vehicle
{
    public class VehicleValidator : AbstractValidator<EVehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.LicensePlate).NotEmpty().WithMessage("La placa es requerida");
            RuleFor(v => v.Appraisal)
                .NotNull().WithMessage("El avaluo es requerido")
                .GreaterThanOrEqualTo(0).WithMessage("El avaluo debe ser mayor o igual a 0");
            RuleFor(v => v.Year)
                .GreaterThanOrEqualTo(0).WithMessage("El año debe ser mayor o igual a 0")
                .NotEmpty().WithMessage("El año es requerido");
            RuleFor(v => v.BrandId).NotEmpty().WithMessage("La marca es requerida");
            RuleFor(v => v.CylinderCapacity).NotEmpty().WithMessage("El cilindraje es requerido");
            RuleFor(v => v.ChassisNumber).NotEmpty().WithMessage("El numero de chasis es requerido");
            RuleFor(v => v.Model).NotEmpty().WithMessage("El modelo es requerido");
            RuleFor(v => v.TypeId).NotEmpty().WithMessage("El tipo es requerido");

        }
    }
}

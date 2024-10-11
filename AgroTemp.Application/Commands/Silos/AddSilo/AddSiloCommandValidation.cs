using AgroTemp.Domain.Enums.Silo;
using FluentValidation;

namespace AgroTemp.Application.Commands.Silos.AddSilo;

public class AddSiloCommandValidation : AbstractValidator<AddSiloCommand>
{
    public AddSiloCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(5).WithMessage("Name cannot be longer than 5 characters.");

        RuleFor(x => x.Size)
            .NotEmpty().WithMessage("Size is required.");

        RuleFor(x => x.PositionX)
            .NotEmpty().WithMessage("Position x is required.")
            .GreaterThan(0).WithMessage("Position x must be greater than 0.");

        RuleFor(x => x.PositionY)
            .NotEmpty().WithMessage("Position y is required.")
            .GreaterThan(0).WithMessage("Position y must be greater than 0.");

        RuleFor(x => x.OrderSensors)
            .NotEmpty().WithMessage("Order of sensors is required.")
            .IsEnumName(typeof(OrderSensors)).WithMessage("Order of sensors has not valid value.");
    }
}

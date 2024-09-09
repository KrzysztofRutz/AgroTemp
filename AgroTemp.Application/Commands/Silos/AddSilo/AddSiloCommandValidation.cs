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
            .GreaterThan(0).WithMessage("Position x can be greater than 0.");

        RuleFor(x => x.PositionY)
            .NotEmpty().WithMessage("Position y is required.")
            .GreaterThan(0).WithMessage("Position y can be greater than 0.");

		RuleFor(x => x.OrderSensors)
            .NotEmpty().WithMessage("Order of sensors is required.")
            .Must(x => x == "FromUp" || x == "FromDown").WithMessage("Order of sensors has not valid name.");
    }
}

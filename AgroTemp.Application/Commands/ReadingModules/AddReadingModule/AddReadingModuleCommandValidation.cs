using FluentValidation;

namespace AgroTemp.Application.Commands.ReadingModules.AddReadingModule;

public class AddReadingModuleCommandValidation : AbstractValidator<AddReadingModuleCommand>
{
    public AddReadingModuleCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(5).WithMessage("Name cannot be longer than 5 characters.");

        RuleFor(x => x.CommunicationType)
            .NotEmpty().WithMessage("Type of communication is required.")
            .Must(x => x == "TCP" || x == "RTU").WithMessage("Type of communication has not valid name.");

        RuleFor(x => x.Port_or_AddressIP)
            .NotEmpty().WithMessage("Serial port/address IP is required.")
            .MaximumLength(15).WithMessage("Serial port/address cannot be longer than 15 characters.");

        RuleFor(x => x.ModuleID)
            .NotEmpty().WithMessage("ID module is required.");

        RuleFor(x => x.Baudrate)
            .NotEmpty().WithMessage("Baudrate is required.");

        RuleFor(x => x.BitsOfSign)
            .NotEmpty().WithMessage("Bits of sign is required.");

        RuleFor(x => x.StopBit)
            .NotEmpty().WithMessage("Bit stop is required.");

        RuleFor(x => x.ModuleType)
            .NotEmpty().WithMessage("Type of module is required.")
            .Must(x => x == "ELECSO" || x == "WIRECHIP").WithMessage("Type of module has not valid name.");
    }
}

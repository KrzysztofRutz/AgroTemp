using AgroTemp.Domain.Enums.ReadingModule;
using FluentValidation;
using System.IO.Ports;

namespace AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;

public class UpdateReadingModuleCommandValidation : AbstractValidator<UpdateReadingModuleCommand>
{
    public UpdateReadingModuleCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(5).WithMessage("Name cannot be longer than 5 characters.");

        RuleFor(x => x.CommunicationType)
            .IsEnumName(typeof(CommunicationType)).WithMessage("Type of communication has not valid value.");

        RuleFor(x => x.Port_or_AddressIP)
            .NotEmpty().WithMessage("Serial port/address IP is required.")
            .MaximumLength(15).WithMessage("Serial port/address cannot be longer than 15 characters.");

        RuleFor(x => x.ModuleID)
            .NotEmpty().WithMessage("ID module is required.")
            .GreaterThan(0).WithMessage("ID module must be greater than 0."); 

        RuleFor(x => x.Baudrate)
            .IsInEnum().WithMessage("Baudrate has not valid value.");

        RuleFor(x => x.BitsOfSign)
            .NotEmpty().WithMessage("Bits of sign is required.")
            .GreaterThan(0).WithMessage("Bits of sign must be greater than 0."); 

        RuleFor(x => x.Parity)
            .IsEnumName(typeof(Parity)).WithMessage("Parity has not valid value.");

        RuleFor(x => x.StopBit)
            .IsEnumName(typeof(StopBits)).WithMessage("Bit stop has not valid value.");

        RuleFor(x => x.ModuleType)
            .IsEnumName(typeof(ModuleType)).WithMessage("Type of module has not valid value.");
    }
}

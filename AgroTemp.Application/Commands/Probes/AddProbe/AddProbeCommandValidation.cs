using FluentValidation;

namespace AgroTemp.Application.Commands.Probes.AddProbe;

public class AddProbeCommandValidation : AbstractValidator<AddProbeCommand>
{
    public AddProbeCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(5).WithMessage("Name cannot be longer than 5 characters.");

        RuleFor(x => x.SensorsCount)
            .NotEmpty().WithMessage("Sensors count is required.")
            .LessThanOrEqualTo(10).WithMessage("Sensors count cannot greater than 10.");

        RuleFor(x => x.NrFirstSensor)
            .NotEmpty().WithMessage("Number first sensor is required.");

        RuleFor(x => x.SiloId)
            .NotEmpty().WithMessage("SiloID is required.");

        RuleFor(x => x.ReadingModuleId)
            .NotEmpty().WithMessage("ReadingModuleId is required.");
    }
}

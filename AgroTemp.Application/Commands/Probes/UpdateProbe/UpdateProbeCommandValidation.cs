using FluentValidation;

namespace AgroTemp.Application.Commands.Probes.UpdateProbe;

public class UpdateProbeCommandValidation : AbstractValidator<UpdateProbeCommand>
{
    public UpdateProbeCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(5).WithMessage("Name cannot be longer than 5 characters.");

        RuleFor(x => x.SensorsCount)
            .NotEmpty().WithMessage("Sensors count is required.")
            .GreaterThan(0).WithMessage("Sensors count must be greater than 0.")
            .LessThanOrEqualTo(10).WithMessage("Sensors count cannot greater than 10.");

        RuleFor(x => x.NrFirstSensor)
            .NotEmpty().WithMessage("Number of first sensor is required.")
            .GreaterThan(0).WithMessage("Number of first sensor must be greater than 0.");

        RuleFor(x => x.NrOfCircle)
            .IsInEnum().WithMessage("Number of circle has not valid value.");

        RuleFor(x => x.SiloId)
            .NotEmpty().WithMessage("SiloID is required.");

        RuleFor(x => x.ReadingModuleId)
            .NotEmpty().WithMessage("ReadingModuleId is required.");
    }
}

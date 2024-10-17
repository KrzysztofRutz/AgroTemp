using FluentValidation;

namespace AgroTemp.Application.Commands.Settings.UpdateHourOfReading;

public class UpdateHourOfReadingCommandValidation : AbstractValidator<UpdateHourOfReadingCommand>
{
    public UpdateHourOfReadingCommandValidation()
    {
        RuleFor(x => x.HourOfReading)
            .GreaterThanOrEqualTo(0).WithMessage("Hour of reading must be least at 0.")
            .LessThan(24).WithMessage("Hour of reading must be less than 24.");
    }
}

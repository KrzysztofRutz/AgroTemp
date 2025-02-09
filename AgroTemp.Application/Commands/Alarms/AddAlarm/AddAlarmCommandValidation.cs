using AgroTemp.Domain.Enums.Alarm;
using FluentValidation;

namespace AgroTemp.Application.Commands.Alarms.AddAlarm;

public class AddAlarmCommandValidation : AbstractValidator<AddAlarmCommand>
{
    public AddAlarmCommandValidation()
    {
        RuleFor(x => x.Description)
            .IsEnumName(typeof(Description)).WithMessage("Description of alarm has not valid value.");

        RuleFor(x => x.ObjectName)
            .NotEmpty().WithMessage("Object name is required.");
    }
}

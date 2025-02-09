using FluentValidation;

namespace AgroTemp.Application.Commands.Alarms.UpdateAlarm;

public class UpdateAlarmCommandValidation : AbstractValidator<UpdateAlarmCommand>
{
    public UpdateAlarmCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}

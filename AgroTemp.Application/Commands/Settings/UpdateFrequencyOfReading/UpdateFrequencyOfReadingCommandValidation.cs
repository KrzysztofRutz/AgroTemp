using FluentValidation;

namespace AgroTemp.Application.Commands.Settings.UpdateFrequencyOfReading;

public class UpdateFrequencyOfReadingCommandValidation : AbstractValidator<UpdateFrequencyOfReadingCommand>
{
    public UpdateFrequencyOfReadingCommandValidation()
    {
        RuleFor(x => x.FrequencyOfReading)
            .IsInEnum().WithMessage("Frequency of reading has not valid value.");
    }
}

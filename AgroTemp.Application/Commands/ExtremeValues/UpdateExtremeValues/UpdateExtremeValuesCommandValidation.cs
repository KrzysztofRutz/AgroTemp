using FluentValidation;

namespace AgroTemp.Application.Commands.ExtremeValues.UpdateExtremeValues;

public class UpdateExtremeValuesCommandValidation : AbstractValidator<UpdateExtremeValuesCommand>
{
    public UpdateExtremeValuesCommandValidation()
    {
        RuleFor(x => x.MaxTemperature)
            .GreaterThan(x => x.MinTemperature).WithMessage("Max temperature must be greater than min temperature.");

        RuleFor(x => x.MinTemperature)
            .LessThan(x => x.MaxTemperature).WithMessage("Min temperature must be less than max temperature.");
    }
}

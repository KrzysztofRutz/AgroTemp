using FluentValidation;

namespace AgroTemp.Application.Commands.Users.UpdateLogin;

public class UpdateLoginCommandValidation : AbstractValidator<UpdateLoginCommand>
{
    public UpdateLoginCommandValidation()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(15).WithMessage("Last name cannot be longer than 15 characters.");
    }
}

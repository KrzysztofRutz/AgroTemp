using AgroTemp.Application.Configuration.Validation;
using FluentValidation;

namespace AgroTemp.Application.Commands.Users.UpdatePassword;

public class UpdatePasswordCommandValidation : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidation()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Must(x => PasswordValidator.HasSpecialCharacter(x)).WithMessage("Password has not any symbol character.")
            .Must(x => PasswordValidator.HasNumberCharacter(x)).WithMessage("Password has not any number character.")
            .MinimumLength(8).WithMessage("Password cannot be shorter than 8 characters.");
    }
}

using AgroTemp.Application.Configuration.Validation;
using AgroTemp.Domain.Enums.User;
using FluentValidation;

namespace AgroTemp.Application.Commands.Users.UpdateUserParameters;

public class UpdateUserParametersCommandValidation : AbstractValidator<UpdateUserParametersCommand>
{
    public UpdateUserParametersCommandValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(15).WithMessage("First name cannot be longer than 15 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(15).WithMessage("Last name cannot be longer than 15 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email has fail syntax.")
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(20).WithMessage("Email cannot be longer than 20 characters.");

        RuleFor(x => x.TypeOfUser)
            .IsEnumName(typeof(TypeOfUser)).WithMessage("Type of user has not valid value.");
    }
}

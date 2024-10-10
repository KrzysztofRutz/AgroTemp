using FluentValidation;

namespace AgroTemp.Application.Commands.Users.AddUser;

public class AddUserCommandValidation : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidation()
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

        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(15).WithMessage("Last name cannot be longer than 15 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Must(x => PasswordHasSpecialCharacter(x)).WithMessage("Password has not any symbol character.")
            .Must(x => PasswordHasNumberCharacter(x)).WithMessage("Password has not any number character.")
            .MinimumLength(8).WithMessage("Password cannot be shorter than 8 characters.")
            .MaximumLength(15).WithMessage("Password cannot be longer than 50 characters.");

        RuleFor(x => x.TypeOfUser)
            .NotEmpty().WithMessage("Type of user is required.")
            .Must(x => x == "Operator" || x == "Manager").WithMessage("Type of user has not valid name.");
    }

    private static bool PasswordHasSpecialCharacter(string password)
    {
        bool valid = false;

        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c))
            {
                valid = true;
                break;
            }
        }

        return valid;
    }

    private static bool PasswordHasNumberCharacter(string password)
    {
        bool valid = false;

        foreach (char c in password)
        {
            if (char.IsNumber(c))
            {
                valid = true;
                break;
            }
        }

        return valid;
    }
}

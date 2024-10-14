using AgroTemp.Domain.Enums.Settings;
using FluentValidation;

namespace AgroTemp.Application.Commands.Settings.UpdateLanguage;

public class UpdateLanguageCommandValidation : AbstractValidator<UpdateLanguageCommand>
{
    public UpdateLanguageCommandValidation()
    {
        RuleFor(x => x.Language)
            .IsEnumName(typeof(Language)).WithMessage("Language has not valid value.");
    }
}

using AgroTemp.Application.Commands.Settings.UpdateLanguage;
using AgroTemp.Domain.Abstractions;
using FluentValidation.TestHelper;

namespace AgroTemp.UnitTests.Commands.Settings.UpdateLanguage;

public class UpdateLanguageCommandValidationTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;

    public UpdateLanguageCommandValidationTests()
    {
        _settingsRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyErrorValidationErrors_WhenUpdateLanguageCommandIsValidation()
    {
        //Arrange 
        var command = new UpdateLanguageCommand()
        {
            Language = "PL",
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateLanguageCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForLanguage_WhenLanguageIsNotInEnum()
    {
        //Arrange 
        var command = new UpdateLanguageCommand()
        {
            Language = "FE",
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateLanguageCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Language);
    }
}

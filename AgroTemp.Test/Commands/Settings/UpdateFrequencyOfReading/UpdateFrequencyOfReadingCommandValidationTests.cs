using AgroTemp.Application.Commands.Settings.UpdateFrequencyOfReading;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Settings;
using FluentValidation.TestHelper;

namespace AgroTemp.UnitTests.Commands.Settings.UpdateFrequencyOfReading;

public class UpdateFrequencyOfReadingCommandValidationTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;

    public UpdateFrequencyOfReadingCommandValidationTests()
    {
        _settingsRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyErrorValidationErrors_WhenUpdateFrequencyOfReadingCommandIsValidation()
    {
        //Arrange 
        var command = new UpdateFrequencyOfReadingCommand()
        {
            FrequencyOfReading = FrequencyOfReading.Every1hour,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateFrequencyOfReadingCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForFrequencyOfReading_WhenFrequencyOfReadingIsNotInEnum()
    {
        //Arrange 
        var command = new UpdateFrequencyOfReadingCommand()
        {
            FrequencyOfReading = default,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateFrequencyOfReadingCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.FrequencyOfReading);
    }
}

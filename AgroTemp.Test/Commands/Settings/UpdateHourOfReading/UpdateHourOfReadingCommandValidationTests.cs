using AgroTemp.Application.Commands.Settings.UpdateHourOfReading;
using AgroTemp.Domain.Abstractions;
using FluentValidation.TestHelper;

namespace AgroTemp.UnitTests.Commands.Settings.UpdateHourOfReading;

public class UpdateHourOfReadingCommandValidationTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;

    public UpdateHourOfReadingCommandValidationTests()
    {
        _settingsRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyErrorValidationErrors_WhenUpdateHourOfReadingCommandIsValidation()
    {
        //Arrange 
        var command = new UpdateHourOfReadingCommand()
        {
            HourOfReading = 15,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateHourOfReadingCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForHourOfReading_WhenHourOfReadingIsLessThan0()
    {
        //Arrange 
        var command = new UpdateHourOfReadingCommand()
        {
            HourOfReading = -5,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateHourOfReadingCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.HourOfReading);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForHourOfReading_WhenHourOfReadingIsGreaterThan23()
    {
        //Arrange 
        var command = new UpdateHourOfReadingCommand()
        {
            HourOfReading = 24,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var validator = new UpdateHourOfReadingCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.HourOfReading);
    }
}

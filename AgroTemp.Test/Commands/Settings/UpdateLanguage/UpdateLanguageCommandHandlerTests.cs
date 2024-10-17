using AgroTemp.Application.Commands.Settings.UpdateLanguage;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.UnitTests.Commands.Settings.UpdateLanguage;

public class UpdateLanguageCommandHandlerTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UpdateLanguageCommandHandlerTests()
    {
        _settingsRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_CallUpdateFrequencyOfReadingOnRepository_WhenUpdateFrequencyOfReadingCommand()
    {
        //Arrange
        var command = new UpdateLanguageCommand()
        {
            Language = "PL",
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var handler = new UpdateLanguageCommandHandler(
            _settingsRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _settingsRepositoryMock.Verify(
            x => x.UpdateLanguage(It.Is<Language>(x => x.ToString() == command.Language)),
            Times.Once);
    }
}

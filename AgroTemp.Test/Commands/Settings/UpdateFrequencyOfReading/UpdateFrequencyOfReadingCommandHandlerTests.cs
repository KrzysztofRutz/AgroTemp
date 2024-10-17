using AgroTemp.Application.Commands.Settings.UpdateFrequencyOfReading;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.UnitTests.Commands.Settings.UpdateFrequencyOfReading;

public class UpdateFrequencyOfReadingCommandHandlerTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UpdateFrequencyOfReadingCommandHandlerTests()
    {
        _settingsRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_CallUpdateFrequencyOfReadingOnRepository_WhenUpdateFrequencyOfReadingCommand()
    {
        //Arrange
        var command = new UpdateFrequencyOfReadingCommand()
        {
            FrequencyOfReading = FrequencyOfReading.Every1hour,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());
        
        var handler = new UpdateFrequencyOfReadingCommandHandler(
            _settingsRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _settingsRepositoryMock.Verify(
            x => x.UpdateFrequencyOfReading(It.Is<FrequencyOfReading>(x => x == command.FrequencyOfReading)),
            Times.Once);
    }
}

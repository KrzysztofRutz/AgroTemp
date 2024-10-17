using AgroTemp.Application.Commands.Settings.UpdateHourOfReading;
using AgroTemp.Domain.Abstractions;

namespace AgroTemp.UnitTests.Commands.Settings.UpdateHourOfReading;

public class UpdateHourOfReadingCommandHandlerTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UpdateHourOfReadingCommandHandlerTests()
    {
        _settingsRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_CallUpdateFrequencyOfReadingOnRepository_WhenUpdateFrequencyOfReadingCommand()
    {
        //Arrange
        var command = new UpdateHourOfReadingCommand()
        {
            HourOfReading = 15,
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>())).ReturnsAsync(new Domain.Entities.Settings());

        var handler = new UpdateHourOfReadingCommandHandler(
            _settingsRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _settingsRepositoryMock.Verify(
            x => x.UpdateHourOfReading(It.Is<int>(x => x == command.HourOfReading)),
            Times.Once);
    }
}

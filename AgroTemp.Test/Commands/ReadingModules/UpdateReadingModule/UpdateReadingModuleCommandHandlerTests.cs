using AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.UnitTests.Commands.ReadingModules.UpdateReadingModule;

public class UpdateReadingModuleCommandHandlerTests
{
    private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UpdateReadingModuleCommandHandlerTests()
    {
        _readingModuleRepositoryMock = new Mock<IReadingModuleRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    [Fact]
    public async Task Handle_Should_CallUpdateOnRepository_WhenReadingModuleIsExists()
    {
        //Arrange
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule() { Id = command.Id });

        var handler = new UpdateReadingModuleCommandHandler(
            _readingModuleRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _readingModuleRepositoryMock.Verify(
            x => x.Update(It.Is<ReadingModule>(x => x.Id == command.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowReadingModuleNotFoundException_WhenReadingModuleIsNotExists()
    {
        //Arrange
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()));

        var handler = new UpdateReadingModuleCommandHandler(
            _readingModuleRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<ReadingModuleNotFoundException>(async () => await handler.Handle(command, default));
    } 
}

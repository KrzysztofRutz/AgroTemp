using AgroTemp.Application.Commands.ReadingModules.RemoveReadingModule;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Exceptions;
using System.IO.Ports;

namespace AgroTemp.UnitTests.Commands.ReadingModules.RemoveReadingModule;

public class RemoveReadingModuleHandlerTests
{
    private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    public RemoveReadingModuleHandlerTests()
    {
        _readingModuleRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_CallDeleteOnRepository_WhenReadingModuleIsExists()
    {
        //Arrange
        var readingModule = new ReadingModule()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = CommunicationType.TCP,
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = Parity.None,
            StopBit = StopBits.One,
            ModuleType = ModuleType.Elecso,
        };

        _readingModuleRepositoryMock.Setup(
            x => x.Add(readingModule));

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                readingModule.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(readingModule);

        var command = new RemoveReadingModuleCommand(readingModule.Id);

        var handler = new RemoveReadingModuleCommandHandler(_readingModuleRepositoryMock.Object, _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _readingModuleRepositoryMock.Verify(x => x.Delete(It.Is<ReadingModule>(x => x.Id == readingModule.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowReadingModuleNotFoundException_WhenReadingModuleIsNotExists()
    {
        //Arrange
        var readingModule = new ReadingModule()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = CommunicationType.TCP,
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = Parity.None,
            StopBit = StopBits.One,
            ModuleType = ModuleType.Elecso,
        };

        _readingModuleRepositoryMock.Setup(
            x => x.Add(readingModule));

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                readingModule.Id,
                It.IsAny<CancellationToken>()));

        var command = new RemoveReadingModuleCommand(readingModule.Id);

        var handler = new RemoveReadingModuleCommandHandler(_readingModuleRepositoryMock.Object, _unitOfWorkMock.Object);

        //Assert
        await Assert.ThrowsAsync<ReadingModuleNotFoundException>(async () => await handler.Handle(command, default));
    }
}

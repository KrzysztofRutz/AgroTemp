using AgroTemp.Application.Commands.Probes.AddProbe;
using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using Moq;

namespace AgroTemp.UnitTests.Commands.Probes.AddProbe;

public class AddProbeCommandHandlerTests
{
    private readonly Mock<IProbeRepository> _probeRepositoryMock;
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;

    public AddProbeCommandHandlerTests()
    {
        _probeRepositoryMock = new();
        _siloRepositoryMock = new();
        _readingModuleRepositoryMock = new();
        _unitOfWorkMock = new();
        _mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallAddProbeOnRepository_WhenNameIsUnique()
    {
        //Arrange
        var command = new AddProbeCommand() 
        { 
            Name = "S1",
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.Add(It.IsAny<Probe>()));

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.SiloId,
                It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.ReadingModuleId,
                It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule());

        var handler = new AddProbeCommandHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _readingModuleRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        //Act
        var probeDto = await handler.Handle(command, default);

        //Assert
        _probeRepositoryMock.Verify(
            x => x.Add(It.Is<Probe>(x => x.Name == probeDto.Name)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowProbeIsAlreadyExists_WhenNameIsNotUnique()
    {
        //Arrange
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.Add(It.IsAny<Probe>()));

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.SiloId,
                It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.ReadingModuleId,
                It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule());

        var handler = new AddProbeCommandHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _readingModuleRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<ProbeIsAlreadyExistException>(async () => await handler.Handle(command, default));
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloIsNotFound_WhenSiloNotExists()
    {
        //Arrange
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.Add(It.IsAny<Probe>()));

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.SiloId,
                It.IsAny<CancellationToken>()));

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.ReadingModuleId,
                It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule());

        var handler = new AddProbeCommandHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _readingModuleRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<SiloNotFoundException>(async () => await handler.Handle(command, default));
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloIsNotFound_WhenReadingModuleNotExists()
    {
        //Arrange
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.Add(It.IsAny<Probe>()));

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.SiloId,
                It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.ReadingModuleId,
                It.IsAny<CancellationToken>()));

        var handler = new AddProbeCommandHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _readingModuleRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<ReadingModuleNotFoundException>(async () => await handler.Handle(command, default));
    }
}

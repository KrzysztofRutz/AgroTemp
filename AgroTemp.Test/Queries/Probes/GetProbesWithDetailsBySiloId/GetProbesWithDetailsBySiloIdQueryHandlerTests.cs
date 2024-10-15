using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Probes.GetProbeById;
using AgroTemp.Application.Queries.Probes.GetProbesWithDetailsBySiloId;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using System.IO.Ports;

namespace AgroTemp.UnitTests.Queries.Probes.GetProbesWithDetailsBySiloId;

public class GetProbesWithDetailsBySiloIdQueryHandlerTests
{
    private readonly Mock<IProbeReadOnlyRepository> _probeReadOnlyRepositoryMock;
    private readonly Mock<ITemperatureRepository> _temperatureRepositoryMock;
    private readonly Mock<IDeltaTemperatureRepository> _deltaTemperatureRepositoryMock;
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    private readonly IMapper _mapper;
    public GetProbesWithDetailsBySiloIdQueryHandlerTests()
    {
        _probeReadOnlyRepositoryMock = new();
        _temperatureRepositoryMock = new();
        _deltaTemperatureRepositoryMock = new();
        _siloRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetGetProbesWithDetailsBySiloIdOnRepository_WhenGetProbesWithDetailsBySiloIdQuery()
    {
        //Arrange
        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

        _probeReadOnlyRepositoryMock.Setup(
            x => x.GetWithDetailsBySiloIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Probe>);

        var handler = new GetProbesWithDetailsBySiloIdQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _deltaTemperatureRepositoryMock.Object, _siloRepositoryMock.Object, _mapper);

        //Act
        await handler.Handle(new GetProbesWithDetailsBySiloIdQuery(1), default);

        //Assert
        _probeReadOnlyRepositoryMock.Verify(
            x => x.GetWithDetailsBySiloIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Throw_SiloNotFoundException_WhenSiloIsNotExists()
    {
        //Arrange
        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()));

        _probeReadOnlyRepositoryMock.Setup(
            x => x.GetWithDetailsBySiloIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Probe>);

        var handler = new GetProbesWithDetailsBySiloIdQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _deltaTemperatureRepositoryMock.Object, _siloRepositoryMock.Object, _mapper);

        //Act & Assert
        await Assert.ThrowsAnyAsync<SiloNotFoundException>(async () => await handler.Handle(new GetProbesWithDetailsBySiloIdQuery(default), default));
    }

    [Fact]
    public async Task Handle_Should_ReturnProbeWithDetailsCollection_WhenGetProbesWithDetailsBySiloIdQuery()
    {
        //Arrange
        var silo = new Silo()
        {
            Id = 1,
            Name = "Z1",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = OrderSensors.FromUp,
        };

        var readingModule = new ReadingModule()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = CommunicationType.RTU,
            Port_or_AddressIP = "COM1",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            StopBit = StopBits.One,
            ModuleType = ModuleType.Elecso
        };

        var probes = new List<Probe>()
        {
            new Probe()
            {
                Id = 1,
                Name = "S1",
                SensorsCount = 3,
                NrFirstSensor = 1,
                SiloId = 1,
                ReadingModuleId = 1,
                Silo = silo,
                ReadingModule = readingModule,
            },
            new Probe()
            {
                Id = 2,
                Name = "S2",
                SensorsCount = 3,
                NrFirstSensor = 1,
                SiloId = 2,
                ReadingModuleId = 1,
                Silo = new Silo
                {
                    Id = 2,
                    Name = "Z2",
                    Size = 100,
                    PositionX = 1,
                    PositionY = 1,
                    OrderSensors = OrderSensors.FromUp,
                },
                ReadingModule = readingModule,
            },
        };

        var temperature = new Temperature()
        {
            Id = 1,
            ReadingModuleId = readingModule.Id,
            sensor1 = 11,
            sensor2 = 11,
            sensor3 = 11,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        var deltaTemperature = new DeltaTemperature()
        {
            Id = 1,
            ReadingModuleId = readingModule.Id,
            sensor1 = 11,
            sensor2 = 11,
            sensor3 = 11,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(silo);

        _probeReadOnlyRepositoryMock.Setup(
            x => x.GetWithDetailsBySiloIdAsync(
                silo.Id,
                It.IsAny<CancellationToken>())).ReturnsAsync(probes.Where(x => x.SiloId == silo.Id));

        _temperatureRepositoryMock.Setup(
            x => x.GetActualMeasureByReadingModuleIdAsync(It.IsAny<int>())).ReturnsAsync(temperature);

        _deltaTemperatureRepositoryMock.Setup(
            x => x.GetActualMeasureByReadingModuleIdAsync(It.IsAny<int>())).ReturnsAsync(deltaTemperature);

        var handler = new GetProbesWithDetailsBySiloIdQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _deltaTemperatureRepositoryMock.Object, _siloRepositoryMock.Object, _mapper);

        //Act
        var probesWithDetailsDto = await handler.Handle(new GetProbesWithDetailsBySiloIdQuery(silo.Id), default);

        //Assert
        Assert.NotEmpty(probesWithDetailsDto);
        Assert.NotNull(probesWithDetailsDto);
    }
}

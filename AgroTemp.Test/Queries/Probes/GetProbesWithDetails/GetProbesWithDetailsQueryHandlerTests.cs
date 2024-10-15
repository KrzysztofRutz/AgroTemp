using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Probes.GetProbesWithDetails;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Enums.Silo;
using AutoMapper;
using System.IO.Ports;

namespace AgroTemp.UnitTests.Queries.Probes.GetProbesWithDetails;

public class GetProbesWithDetailsQueryHandlerTests
{
	private readonly Mock<IProbeReadOnlyRepository> _probeReadOnlyRepositoryMock;
    private readonly Mock<ITemperatureRepository> _temperatureRepositoryMock;
    private readonly Mock<IDeltaTemperatureRepository> _deltaTemperatureRepositoryMock;
    private readonly IMapper _mapper;

	public GetProbesWithDetailsQueryHandlerTests()
	{
		_probeReadOnlyRepositoryMock = new();
        _temperatureRepositoryMock = new();
        _deltaTemperatureRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
	}

	[Fact]
	public async Task Handle_Should_CallGetGetProbesWithDetailsOnRepository_WhenGetProbesWithDetailsQuery()
	{
		//Arrange
		_probeReadOnlyRepositoryMock.Setup(
			x => x.GetAllWithDetailsAsync(
				It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Probe>);

		var handler = new GetProbesWithDetailsQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _deltaTemperatureRepositoryMock.Object, _mapper);

		//Act
		await handler.Handle(new GetProbesWithDetailsQuery(), default);

		//Assert
		_probeReadOnlyRepositoryMock.Verify(
			x => x.GetAllWithDetailsAsync(
				It.IsAny<CancellationToken>()),
			Times.Once);
	}

	[Fact]
	public async Task Handle_Should_ReturnProbeWithDetailsCollection_WhenGetProbesWithDetailsQuery()
	{
		//Arrange
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
				Silo = new Silo
				{
					Id = 1,
					Name = "Z1",
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

        _probeReadOnlyRepositoryMock.Setup(
			x => x.GetAllWithDetailsAsync(
				It.IsAny<CancellationToken>())).ReturnsAsync(probes);

        _temperatureRepositoryMock.Setup(
            x => x.GetActualMeasureByReadingModuleIdAsync(It.IsAny<int>())).ReturnsAsync(temperature);

        _deltaTemperatureRepositoryMock.Setup(
			x => x.GetActualMeasureByReadingModuleIdAsync(It.IsAny<int>())).ReturnsAsync(deltaTemperature);

        var handler = new GetProbesWithDetailsQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _deltaTemperatureRepositoryMock.Object, _mapper);

		//Act
		var probesWithDetailsDto = await handler.Handle(new GetProbesWithDetailsQuery(), default);

		//Assert
		Assert.NotEmpty(probesWithDetailsDto);
		Assert.NotNull(probesWithDetailsDto);
	}
}

using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Probes.GetProbesWithDetails;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Enums.Silo;
using AutoMapper;
using Moq;
using System.IO.Ports;

namespace AgroTemp.UnitTests.Queries.Probes.GetProbesWithDetails;

public class GetProbesWithDetailsQueryHandlerTests
{
	private readonly Mock<IProbeReadOnlyRepository> _probeReadOnlyRepositoryMock;
    private readonly Mock<ITemperatureRepository> _temperatureRepositoryMock;
    private readonly IMapper _mapper;

	public GetProbesWithDetailsQueryHandlerTests()
	{
		_probeReadOnlyRepositoryMock = new Mock<IProbeReadOnlyRepository>();
        _temperatureRepositoryMock = new Mock<ITemperatureRepository>();
        _mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
	}

	[Fact]
	public async Task Handle_Should_CallGetGetProbesWithDetailsOnRepository_WhenGetProbesWithDetailsQuery()
	{
		//Arrange
		_probeReadOnlyRepositoryMock.Setup(
			x => x.GetAllWithDetailsAsync(
				It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Probe>);

		var handler = new GetProbesWithDetailsQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _mapper);

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
		var probes = new List<Probe>() 
		{
			new Probe()
			{
				Id = 1,
				Name = "S1",
				SensorsCount = 7,
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
				ReadingModule = new ReadingModule
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
				}
			},
			new Probe()
			{
				Id = 2,
				Name = "S2",
				SensorsCount = 5,
				NrFirstSensor = 11,
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
				ReadingModule = new ReadingModule
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
				}
			},
		};

		_probeReadOnlyRepositoryMock.Setup(
			x => x.GetAllWithDetailsAsync(
				It.IsAny<CancellationToken>())).ReturnsAsync(probes);

		var handler = new GetProbesWithDetailsQueryHandler(_probeReadOnlyRepositoryMock.Object, _temperatureRepositoryMock.Object, _mapper);

		//Act
		var probesWithDetailsDto = await handler.Handle(new GetProbesWithDetailsQuery(), default);

		//Assert
		Assert.NotEmpty(probesWithDetailsDto);
		Assert.NotNull(probesWithDetailsDto);
	}
}

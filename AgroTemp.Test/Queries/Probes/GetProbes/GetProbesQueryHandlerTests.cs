using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Probes.GetProbes;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AutoMapper;
using Moq;

namespace AgroTemp.UnitTests.Queries.Probes.GetProbes;

public class GetProbesQueryHandlerTests
{
	private readonly Mock<IProbeReadOnlyRepository> _probeReadOnlyRepositoryMock;
	private readonly IMapper _mapper;

	public GetProbesQueryHandlerTests()
	{
		_probeReadOnlyRepositoryMock = new Mock<IProbeReadOnlyRepository>();
		_mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
	}

	[Fact]
	public async Task Handle_Should_CallGetAllAsyncOnRepository_WhenGetProbeQuery()
	{
		//Arrange
		_probeReadOnlyRepositoryMock.Setup(
			x => x.GetAllAsync(
				It.IsAny<CancellationToken>())).
				ReturnsAsync(Enumerable.Empty<Probe>);

		var handler = new GetProbesQueryHandler(
			_probeReadOnlyRepositoryMock.Object,
			_mapper);

		// Act
		await handler.Handle(new GetProbesQuery(), default);

		// Assert
		_probeReadOnlyRepositoryMock.Verify(
		   x => x.GetAllAsync(
		   It.IsAny<CancellationToken>()),
		   Times.Once
		   );
	}

	[Fact]
	public async Task Handle_Should_ReturnNotEmptyCollection_WhenGetProbessQuery()
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
			},
			new Probe()
			{
				Id = 2,
				Name = "S2",
				SensorsCount = 5,
				NrFirstSensor = 11,
				SiloId = 1,
				ReadingModuleId = 1,
			},
		};

		_probeReadOnlyRepositoryMock.Setup(
			x => x.GetAllAsync(
				It.IsAny<CancellationToken>())).ReturnsAsync(probes);

		var handler = new GetProbesQueryHandler(
			_probeReadOnlyRepositoryMock.Object,
			_mapper);

		// Act
		var probesDto = await handler.Handle(new GetProbesQuery(), default);

		// Assert
		Assert.NotEmpty(probesDto);
	}
}

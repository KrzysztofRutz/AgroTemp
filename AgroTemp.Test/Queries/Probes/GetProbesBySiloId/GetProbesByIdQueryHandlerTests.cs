using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Probes.GetProbesBySiloId;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace AgroTemp.UnitTests.Queries.Probes.GetProbesBySiloId;

public class GetProbesByIdQueryHandlerTests
{
	private readonly Mock<IProbeRepository> _probeRepositoryMock;
	private readonly Mock<ISiloRepository> _siloRepositoryMock;
	private readonly IMapper _mapper;

	public GetProbesByIdQueryHandlerTests()
	{
		_probeRepositoryMock = new();
		_siloRepositoryMock = new();
		_mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
	}

	[Fact]
	public async Task Handle_Should_CallGetProbesBySiloIdOnRepository_WhenGetProbeBySiloIdQuery()
	{
		//Arrange 
		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				It.IsAny<int>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

		_probeRepositoryMock.Setup(
			x => x.GetBySiloIdAsync(
				It.IsAny<int>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<Probe>());

		var handler = new GetProbesBySiloIdQueryHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _mapper);

		//Act
		await handler.Handle(new GetProbesBySiloIdQuery(It.IsAny<int>()), default);

		//Assert
		_probeRepositoryMock.Verify(
			x => x.GetBySiloIdAsync(
				It.IsAny<int>(),
				It.IsAny<CancellationToken>()),
			Times.Once);
	}

	[Fact]
	public async Task Handle_Should_ReturnProbeCollection_WhenGetProbeBySiloIdQuery()
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

		var anyProbe = probes.ElementAtOrDefault(0);

		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				anyProbe.SiloId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

		_probeRepositoryMock.Setup(
			x => x.GetBySiloIdAsync(
				anyProbe.SiloId,
				It.IsAny<CancellationToken>())).ReturnsAsync(probes);

		var handler = new GetProbesBySiloIdQueryHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _mapper);

		//Act
		var probesDto = await handler.Handle(new GetProbesBySiloIdQuery(anyProbe.SiloId), default);

		//Assert
		probesDto.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Handle_Should_ThrowSiloNotFoundException_WhenSiloIsNotExists()
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

		var anyProbe = probes.ElementAtOrDefault(0);

		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				anyProbe.SiloId,
				It.IsAny<CancellationToken>()));

		_probeRepositoryMock.Setup(
			x => x.GetBySiloIdAsync(
				anyProbe.SiloId,
				It.IsAny<CancellationToken>())).ReturnsAsync(probes);

		var handler = new GetProbesBySiloIdQueryHandler(_probeRepositoryMock.Object, _siloRepositoryMock.Object, _mapper);

		//Act & Assert
		await Assert.ThrowsAsync<SiloNotFoundException>(async () => await handler.Handle(new GetProbesBySiloIdQuery(anyProbe.SiloId), default));
	}
}

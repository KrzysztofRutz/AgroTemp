using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Probes.GetProbeById;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace AgroTemp.UnitTests.Queries.Probes.GetProbeById;

public class GetProbeByIdQueryHandlerTests
{
	private readonly Mock<IProbeRepository> _probeRepositoryMock;	
	private readonly IMapper _mapper;

	public GetProbeByIdQueryHandlerTests()
	{
		_probeRepositoryMock = new ();
		_mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
	}

	[Fact]
	public async Task Handle_Should_CallGetByIdOnRepository_WhenGetProbeByIdQuery()
	{
		//Arrange
		_probeRepositoryMock.Setup(
			x => x.GetByIdAsync(
				It.IsAny<int>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(new Probe());

		var handler = new GetProbeByIdQueryHandler(_probeRepositoryMock.Object, _mapper);

		//Act
		await handler.Handle(new GetProbeByIdQuery(default), default);

		//Assert
		_probeRepositoryMock.Verify(
		   x => x.GetByIdAsync(
			   It.IsAny<int>(),
			   It.IsAny<CancellationToken>()),
			   Times.Once
		   );
	}

	[Fact]
	public async Task Handle_Should_ReturnProbe_When_ProbeByIdQuery()
	{
		//Arrange
		var probe = new Probe()
		{
			Id = 1,
			Name = "S1",
			SensorsCount = 7,
			NrFirstSensor = 1,
			SiloId = 1,
			ReadingModuleId = 1,
		};

		_probeRepositoryMock.Setup(
			x => x.GetByIdAsync(
				probe.Id,
				It.IsAny<CancellationToken>())).ReturnsAsync(probe);

		var handler = new GetProbeByIdQueryHandler(_probeRepositoryMock.Object, _mapper);

		//Act
		var probeDto = await handler.Handle(new GetProbeByIdQuery(probe.Id), default);

		//Assert
		probeDto.Should().NotBeNull();
	}

	[Fact]
	public async Task Handle_Should_ThrowProbeNotFound_When_ProbeIsNotExists()
	{
		_probeRepositoryMock.Setup(
			x => x.GetByIdAsync(
				It.IsAny<int>(),
				It.IsAny<CancellationToken>()));

		var handler = new GetProbeByIdQueryHandler(_probeRepositoryMock.Object, _mapper);

		//Act & Assert
		await Assert.ThrowsAsync<ProbeNotFoundException>(async () => await handler.Handle(new GetProbeByIdQuery(default), default));
	}
}

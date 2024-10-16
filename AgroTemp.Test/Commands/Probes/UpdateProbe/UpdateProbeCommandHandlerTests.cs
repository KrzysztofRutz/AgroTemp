using AgroTemp.Application.Commands.Probes.UpdateProbe;
using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using Moq;

namespace AgroTemp.UnitTests.Commands.Probes.UpdateProbe;

public class UpdateProbeCommandHandlerTests
{
	private readonly Mock<IProbeRepository> _probeRepositoryMock;
	private readonly Mock<ISiloRepository> _siloRepositoryMock;
	private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;
	private readonly IMapper _mapper;

	public UpdateProbeCommandHandlerTests()
	{
		_probeRepositoryMock = new();
		_siloRepositoryMock = new();
		_readingModuleRepositoryMock = new();
		_unitOfWorkMock = new();
		_mapper = MapperHelper.CreateMapper(new ProbeMappingProfile());
	}

	[Fact]
	public async Task Handle_Should_CallOnRepository_WhenProbeIsExists()
	{
		//Arrange
		var command = new UpdateProbeCommand() 
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
				command.Id,
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(new Probe()
			{
				Id = command.Id,
				Name = "S2",
				SensorsCount = 5,
				NrFirstSensor = 11,
				SiloId = 1,
				ReadingModuleId = 1,
			});

		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.SiloId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

		_readingModuleRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.ReadingModuleId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule());

		var handler = new UpdateProbeCommandHandler(
			_probeRepositoryMock.Object,
			_siloRepositoryMock.Object,
			_readingModuleRepositoryMock.Object,
			_mapper,
			_unitOfWorkMock.Object);

		//Act
		await handler.Handle(command, default);

		//Assert
		_probeRepositoryMock.Verify(
			x => x.Update(It.Is<Probe>(x => x.Id == command.Id)),
			Times.Once);
	}

	[Fact]
	public async Task Handle_Should_ThrowProbeNotFoundException_WhenProbeIsNotExists()
	{
		//Arrange
		var command = new UpdateProbeCommand()
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
				command.Id,
				It.IsAny<CancellationToken>()));
			
		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.SiloId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

		_readingModuleRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.ReadingModuleId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule());

		var handler = new UpdateProbeCommandHandler(
			_probeRepositoryMock.Object,
			_siloRepositoryMock.Object,
			_readingModuleRepositoryMock.Object,
			_mapper,
			_unitOfWorkMock.Object);

		//Act & Assert
		await Assert.ThrowsAsync<ProbeNotFoundException>(async () => await handler.Handle(command, default));
	}

	[Fact]
	public async Task Handle_Should_ThrowSiloNotFoundException_WhenSiloIsNotExists()
	{
		//Arrange
		var command = new UpdateProbeCommand()
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
				command.Id,
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(new Probe()
				{
					Id = command.Id,
					Name = "S2",
					SensorsCount = 5,
					NrFirstSensor = 11,
					SiloId = 1,
					ReadingModuleId = 1,
				});
		;

		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.SiloId,
				It.IsAny<CancellationToken>()));

		_readingModuleRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.ReadingModuleId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new ReadingModule());

		var handler = new UpdateProbeCommandHandler(
			_probeRepositoryMock.Object,
			_siloRepositoryMock.Object,
			_readingModuleRepositoryMock.Object,
			_mapper,
			_unitOfWorkMock.Object);

		//Act & Assert
		await Assert.ThrowsAsync<SiloNotFoundException>(async () => await handler.Handle(command, default));
	}

	[Fact]
	public async Task Handle_Should_ThrowReadingModuleNotFoundException_WhenReadingModuleIsNotExists()
	{
		//Arrange
		var command = new UpdateProbeCommand()
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
				command.Id,
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(new Probe()
			{
				Id = command.Id,
				Name = "S2",
				SensorsCount = 5,
				NrFirstSensor = 11,
				SiloId = 1,
				ReadingModuleId = 1,
			});
		;

		_siloRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.SiloId,
				It.IsAny<CancellationToken>())).ReturnsAsync(new Silo());

		_readingModuleRepositoryMock.Setup(
			x => x.GetByIdAsync(
				command.ReadingModuleId,
				It.IsAny<CancellationToken>()));

		var handler = new UpdateProbeCommandHandler(
			_probeRepositoryMock.Object,
			_siloRepositoryMock.Object,
			_readingModuleRepositoryMock.Object,
			_mapper,
			_unitOfWorkMock.Object);

		//Act & Assert
		await Assert.ThrowsAsync<ReadingModuleNotFoundException>(async () => await handler.Handle(command, default));
	}
}

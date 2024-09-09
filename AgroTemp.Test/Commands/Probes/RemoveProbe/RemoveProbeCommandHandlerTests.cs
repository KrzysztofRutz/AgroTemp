using AgroTemp.Application.Commands.Probes.RemoveProbe;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using Moq;

namespace AgroTemp.UnitTests.Commands.Probes.RemoveProbe;

public class RemoveProbeCommandHandlerTests
{
    private readonly Mock<IProbeRepository> _probeRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public RemoveProbeCommandHandlerTests()
    {
        _probeRepositoryMock = new ();
		_unitOfWorkMock = new ();
    }

    [Fact]
    public async Task Handle_Should_CallOnRepository_WhenProbeIsExists()
    {
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
            x => x.Add(probe));

		_probeRepositoryMock.Setup(
			x => x.GetByIdAsync(
				probe.Id,
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(probe);

		var command = new RemoveProbeCommand(probe.Id);

		var handler = new RemoveProbeCommandHandler(_probeRepositoryMock.Object, _unitOfWorkMock.Object);

		//Act
		await handler.Handle(command, default);

		//Assert
		_probeRepositoryMock.Verify(x => x.Delete(It.Is<Probe>(x => x.Id == probe.Id)),
			Times.Once);
	}

	[Fact]
	public async Task Handle_Should_ThrowProbeNotFoundException_WhenProbeIsNotExists()
	{
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
			x => x.Add(probe));

		_probeRepositoryMock.Setup(
			x => x.GetByIdAsync(
				probe.Id,
				It.IsAny<CancellationToken>()));

		var command = new RemoveProbeCommand(probe.Id);

		var handler = new RemoveProbeCommandHandler(_probeRepositoryMock.Object, _unitOfWorkMock.Object);

		//Act & Assert
		await Assert.ThrowsAsync<ProbeNotFoundException>(async () => await handler.Handle(command, default));
	}
}

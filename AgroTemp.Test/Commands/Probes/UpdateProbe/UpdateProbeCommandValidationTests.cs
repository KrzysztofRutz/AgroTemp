using AgroTemp.Application.Commands.Probes.UpdateProbe;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using FluentValidation.TestHelper;
using Moq;

namespace AgroTemp.UnitTests.Commands.Probes.UpdateProbe;

public class UpdateProbeCommandValidationTests
{
    private readonly Mock<IProbeRepository> _probeRepositoryMock;
    public UpdateProbeCommandValidationTests()
    {
        _probeRepositoryMock = new ();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyErrorValidationErrors_WhenUpdateProbeCommandIsValidation()
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
				Name = "S22",
				SensorsCount = 7,
				NrFirstSensor = 2,
				SiloId = 1,
				ReadingModuleId = 1,
			});

		var validator = new UpdateProbeCommandValidation();

		//Act
		var validationResult = validator.TestValidate(command);

		//Assert
		validationResult.ShouldNotHaveAnyValidationErrors();
	}

	[Fact]
	public void ValidationResult_Shoul_HaveErrorValidationErrorForName_WhenNameIsEmpty()
	{
		//Arrange 
		var command = new UpdateProbeCommand()
		{
			Id = 1,
			Name = string.Empty,
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
				Name = "S22",
				SensorsCount = 7,
				NrFirstSensor = 2,
				SiloId = 1,
				ReadingModuleId = 1,
			});

		var validator = new UpdateProbeCommandValidation();

		//Act
		var validationResult = validator.TestValidate(command);

		//Assert
		validationResult.ShouldHaveValidationErrorFor(x => x.Name);
	}

	[Fact]
	public void ValidationResult_Shoul_HaveErrorValidationErrorForName_WhenNameHasGreaterThan5Characters()
	{
		//Arrange 
		var command = new UpdateProbeCommand()
		{
			Id = 1,
			Name = "S12345",
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
				Name = "S22",
				SensorsCount = 7,
				NrFirstSensor = 2,
				SiloId = 1,
				ReadingModuleId = 1,
			});

		var validator = new UpdateProbeCommandValidation();

		//Act
		var validationResult = validator.TestValidate(command);

		//Assert
		validationResult.ShouldHaveValidationErrorFor(x => x.Name);
	}
}

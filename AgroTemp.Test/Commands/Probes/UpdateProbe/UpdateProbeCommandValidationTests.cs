using AgroTemp.Application.Commands.Probes.UpdateProbe;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using FluentValidation.TestHelper;

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
	public void ValidationResult_Should_HaveErrorValidationErrorForName_WhenNameIsEmpty()
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
	public void ValidationResult_Should_HaveErrorValidationErrorForName_WhenNameHasGreaterThan5Characters()
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

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForSensorsCount_WhenSensorsCountIsEmpty()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = default,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SensorsCount);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForSensorsCount_WhenSensorsCountIsLessThan0()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = -5,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SensorsCount);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForSensorsCount_WhenSensorsCountIsGreaterThan10()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = 12,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SensorsCount);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForNrFirstSensor_WhenNrFirstSensorIsEmpty()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = 5,
            NrFirstSensor = default,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.NrFirstSensor);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForNrFirstSensor_WhenNrFirstSensorIsLessThan0()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = 5,
            NrFirstSensor = -5,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.NrFirstSensor);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForSiloId_WhenSiloIdIsEmpty()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = 5,
            NrFirstSensor = 5,
            SiloId = default,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SiloId);
    }

    [Fact]
    public void ValidationResult_Should_HaveErrorValidationErrorForReadingModuleId_WhenReadingModuleIdIsEmpty()
    {
        //Arrange 
        var command = new UpdateProbeCommand()
        {
            Id = 1,
            Name = "S12",
            SensorsCount = 5,
            NrFirstSensor = 5,
            SiloId = 1,
            ReadingModuleId = default,
        };

        _probeRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Probe());

        var validator = new UpdateProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.ReadingModuleId);
    }
}

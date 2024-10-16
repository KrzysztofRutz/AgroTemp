using AgroTemp.Application.Commands.Probes.AddProbe;
using AgroTemp.Domain.Abstractions;
using FluentValidation.TestHelper;

namespace AgroTemp.UnitTests.Commands.Probes.AddProbe;

public class AddProbeCommandValidationTests
{
    private readonly Mock<IProbeRepository> _probeRepositoryMock;

    public AddProbeCommandValidationTests()
    {
        _probeRepositoryMock = new ();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyValidationErrors_WhenAddProbeCommandIsValidated()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForName_WhenNameIsEmpty()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = string.Empty,
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForName_WhenNameHasGreaterThan5Characters()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1234567",
            SensorsCount = 7,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForSensorCount_WhenSensorsCountIsEmpty()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = default,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SensorsCount);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForSensorCount_WhenSensorsCountIsLessThan0()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = -5,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SensorsCount);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForSensorCount_WhenSensorsCountHasGreaterThan10()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 12,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SensorsCount);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForNrFirstSensor_WhenNrFirstSensorIsEmpty()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 9,
            NrFirstSensor = default,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.NrFirstSensor);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForNrFirstSensor_WhenNrFirstSensorIsLessThan0()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 9,
            NrFirstSensor = -5,
            SiloId = 1,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.NrFirstSensor);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForSiloId_WhenSiloIdIsEmpty()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 9,
            NrFirstSensor = 1,
            SiloId = default,
            ReadingModuleId = 1,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.SiloId);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForReadingModuleId_WhenReadingModuleIdIsEmpty()
    {
        //Arrange 
        var command = new AddProbeCommand()
        {
            Name = "S1",
            SensorsCount = 9,
            NrFirstSensor = 1,
            SiloId = 1,
            ReadingModuleId = default,
        };

        _probeRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddProbeCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.ReadingModuleId);
    }

}

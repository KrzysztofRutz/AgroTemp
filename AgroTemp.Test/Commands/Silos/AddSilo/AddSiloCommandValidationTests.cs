using AgroTemp.Application.Commands.Silos.AddSilo;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Silo;
using FluentValidation.TestHelper;
using Moq;

namespace AgroTemp.UnitTests.Commands.Silos.AddSilo;

public class AddSiloCommandValidationTests
{
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    public AddSiloCommandValidationTests()
    {
        _siloRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyValidationErrors_WhenAddSiloCommandIsValidated()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z1",
            Size = 100,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForName_WhenNameIsEmpty()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = string.Empty,
            Size = 100,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForName_WhenNameHasMoreThan5Characters()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z11111111111",
            Size = 100,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForSize_WhenSizeIsEmpty()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z1",
            Size = default,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Size);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPositionX_WhenPositionXIsEmpty()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z1",
            Size = 100,
            PositionX = default,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.PositionX);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPositionY_WhenPositionYIsEmpty()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z1",
            Size = 100,
            PositionX = 12,
            PositionY = default,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.PositionY);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForOrderSensors_WhenOrderSensorsIsEmpty()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z1",
            Size = 100,
            PositionX = 12,
            PositionY = 12,
            OrderSensors = "OrderSensors.FromDown"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.OrderSensors);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForOrderSensors_WhenOrderSensorsHasNotValidName()
    {
        //Arrange 
        var command = new AddSiloCommand
        {
            Name = "Z1",
            Size = 100,
            PositionX = 12,
            PositionY = 12,
            OrderSensors = "OrderSensors.FromDown"
        };

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.OrderSensors);
    }
}

using AgroTemp.Application.Commands.Silos.AddSilo;
using AgroTemp.Application.Commands.Silos.UpdateSilo;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using FluentValidation.TestHelper;
using Moq;

namespace AgroTemp.UnitTests.Commands.Silos.UpdateSilo;

public class UpdateSiloCommandValidationTests
{
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    public UpdateSiloCommandValidationTests()
    {
        _siloRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyValidationErrors_WhenUpdateSiloCommandIsValidated()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z1",
            Size = 100,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForName_WhenNameIsEmpty()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = string.Empty,
            Size = 100,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForName_WhenNameHasMoreThan5Characters()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z111111111111111111111111111111",
            Size = 100,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp",
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForSize_WhenSizeIsEmpty()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z11",
            Size = default,
            PositionX = 1,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Size);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPositionX_WhenPositionXIsEmpty()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z11",
            Size = 100,
            PositionX = default,
            PositionY = 2,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.PositionX);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPositionY_WhenPositionYIsEmpty()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z11",
            Size = 100,
            PositionX = 1,
            PositionY = default,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.PositionY);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForOrderSensors_WhenOrderSensorsIsEmpty()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z11",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.OrderSensors);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForOrderSensors_WhenOrderSensorsHasNotValidName()
    {
        //Arrange 
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Z11",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = "OrderSensors.FromUp"
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var validator = new UpdateSiloCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.OrderSensors);
    }
}

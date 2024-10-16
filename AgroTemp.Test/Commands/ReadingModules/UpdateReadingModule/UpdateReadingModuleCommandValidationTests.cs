using AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using FluentValidation.TestHelper;

namespace AgroTemp.UnitTests.Commands.ReadingModules.UpdateReadingModule;

public class UpdateReadingModuleCommandValidationTests
{
    private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
    public UpdateReadingModuleCommandValidationTests()
    {
        _readingModuleRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyErrorValidationErrors_WhenUpdateReadingModuleCommandIsValidation()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForName_WhenNameIsEmpty()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = string.Empty,
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForName_WhenNameHasGreaterThan5Characters()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = string.Empty,
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForCommunicationType_WhenNameIsNotEnumName()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = string.Empty,
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.CommunicationType);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForPortOrAddressIP_WhenPortOrAddressIpIsEmpty()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = string.Empty,
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Port_or_AddressIP);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForPortOrAddressIP_WhenPortOrAddressIpIsGreaterThan15Characters()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "1920.1680.2500.1234124",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Port_or_AddressIP);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForModuleID_WhenModuleIDIsEmpty()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.100",
            ModuleID = default,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.ModuleID);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForModuleID_WhenModuleIDIsLessThan0()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.250.123",
            ModuleID = -1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.ModuleID);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForBaudrate_WhenBaudrateIsNotInEnum()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = default,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Baudrate);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForBitsOfSign_WhenBitsOfSignIsEmpty()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs110,
            BitsOfSign = default,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.BitsOfSign);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForBitsOfSign_WhenBitsOfSignIsLessThan0()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs110,
            BitsOfSign = -10,
            Parity = "None",
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.BitsOfSign);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForParity_WhenParityIsNotEnumName()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = string.Empty,
            StopBit = "One",
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Parity);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForStopBit_WhenStopBitIsNotEnumName()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = string.Empty,
            ModuleType = "Elecso",
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.StopBit);
    }

    [Fact]
    public void ValidationResult_Shoul_HaveErrorValidationErrorForModuleType_WhenModuleTypeIsNotEnumName()
    {
        //Arrange 
        var command = new UpdateReadingModuleCommand()
        {
            Id = 1,
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = "None",
            StopBit = "One",
            ModuleType = string.Empty,
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule() { Id = command.Id });

        var validator = new UpdateReadingModuleCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.ModuleType);
    }
}

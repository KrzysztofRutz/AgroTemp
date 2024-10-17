using AgroTemp.Application.Commands.Users.UpdateUser;
using AgroTemp.Domain.Abstractions;
using FluentValidation.TestHelper;

namespace AgroTemp.UnitTests.Commands.Users.UpdateUser;

public class UpdateUserCommandValidationTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    public UpdateUserCommandValidationTests()
    {
        _userRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyValidationErrors_WhenUpdateUserCommandIsValidated()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForFirstName_WhenFirstNameIsEmpty()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = string.Empty,
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForFirstName_WhenFirstNameIsGreaterThan15Characters()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotfqwewqererwtwretrwt",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForLastName_WhenLastNameIsEmpty()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzysztof",
            LastName = string.Empty,
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForLastName_WhenLastNameIsGreaterThan15Characters()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszotfqwewqererwtwretrwt",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForEmail_WhenEmailHasFailSyntax()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzysztofke",
            Email = "mm99gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForEmail_WhenEmailIsEmpty()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzysztofke",
            Email = string.Empty,
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForEmail_WhenEmailIsGreaterThan20Characters()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzysztofke",
            Email = "krzysazsogsodgsdog.123213@gmail.com",
            Login = "mm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForLogin_WhenLoginIsEmpty()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzysztof",
            LastName = "Rtzas",
            Email = "mm99@gmail.com",
            Login = string.Empty,
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Login);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForLogin_WhenLoginIsGreaterThan15Characters()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszot",
            Email = "mm99@gmail.com",
            Login = "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm99",
            Password = "password0@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Login);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPassword_WhenPasswordIsEmpty()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszot",
            Email = "mm99@gmail.com",
            Login = "mmm99",
            Password = string.Empty,
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPassword_WhenPasswordHasNotAnySymbolCharacter()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszot",
            Email = "mm99@gmail.com",
            Login = "mmm99",
            Password = "Passsword010101",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPassword_WhenPasswordHasNotAnyNumberCharacter()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszot",
            Email = "mm99@gmail.com",
            Login = "mmm99",
            Password = "Passsword@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForPassword_WhenPasswordIsLessThan8Characters()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszot",
            Email = "mm99@gmail.com",
            Login = "mmm99",
            Password = "P@s01",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void ValidationResult_Should_HaveAnyValidationErrorForTypeOfUser_WhenTypeOfUserIsNotEnumName()
    {
        //Arrange 
        var command = new UpdateUserCommand()
        {
            FirstName = "Krzyszotf",
            LastName = "Krzyszot",
            Email = "mm99@gmail.com",
            Login = "mmm99",
            Password = "P@s010101010101",
            TypeOfUser = "string.Empty"
        };

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new UpdateUserCommandValidation();

        //Act
        var validationResult = validator.TestValidate(command);

        //Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.TypeOfUser);
    }
}

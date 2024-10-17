using AgroTemp.Application.Commands.Users.UpdateUser;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.UnitTests.Commands.Users.UpdateUser;

public class UpdateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UpdateUserCommandHandlerTests()
    {
        _userRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handler_Should_CallUpdateOnRepository_WhenUserIsExists()
    {
        //Arrange
        var command = new UpdateUserCommand()
        {
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password01@",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var handler = new UpdateUserCommandHandler(
            _userRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _userRepositoryMock.Verify(
            x => x.Update(It.Is<User>(x => x.Id == command.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handler_Should_ThrowSiloNotFoundException_WhenSiloIsNotExists()
    {
        //Arrange
        var command = new UpdateUserCommand()
        {
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password01@",
            TypeOfUser = "Operator"
        };

        var result = _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()));

        var handler = new UpdateUserCommandHandler(
            _userRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<UserNotFoundException>(async () => await handler.Handle(command, default));
    }
}

using AgroTemp.Application.Commands.Users.RemoveUser;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.User;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.UnitTests.Commands.Users.RemoveUser;

public class RemoveUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    public RemoveUserCommandHandlerTests()
    {
        _userRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_CallDeleteOnRepository_WhenUserIsExists()
    {
        //Arrange
        var user = new User()
        {
            Id = 1,
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password",
            TypeOfUser = TypeOfUser.Operator,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        _userRepositoryMock.Setup(
            x => x.Add(user));

        _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                user.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var command = new RemoveUserCommand(user.Id);

        var handler = new RemoveUserCommandHandler(_userRepositoryMock.Object, _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _userRepositoryMock.Verify(x => x.Delete(It.Is<User>(x => x.Id == user.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloNotFoundException_WhenUserIsNotExists()
    {
        //Arrange
        var user = new User()
        {
            Id = 1,
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password",
            TypeOfUser = TypeOfUser.Operator,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        _userRepositoryMock.Setup(
            x => x.Add(user));

        _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                user.Id,
                It.IsAny<CancellationToken>()));

        var command = new RemoveUserCommand(user.Id);

        var handler = new RemoveUserCommandHandler(_userRepositoryMock.Object, _unitOfWorkMock.Object);

        //Assert
        await Assert.ThrowsAsync<UserNotFoundException>(async () => await handler.Handle(command, default));
    }
}

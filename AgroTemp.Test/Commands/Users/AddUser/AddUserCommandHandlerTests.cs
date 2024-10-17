using AgroTemp.Application.Commands.Users.AddUser;
using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.UnitTests.Commands.Users.AddUser;

public class AddUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;
    public AddUserCommandHandlerTests()
    {
        _userRepositoryMock = new();
        _unitOfWorkMock = new();
        _mapper = MapperHelper.CreateMapper(new UserMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenLoginIsUnique()
    {
        //Arrange 
        var command = new AddUserCommand()
        {
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.Add(It.IsAny<User>()));

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new AddUserCommandHandler(
            _userRepositoryMock.Object,
            _mapper,
            _unitOfWorkMock.Object);

        //Act
        var userDto = await handler.Handle(command, default);

        //Assert 
        _userRepositoryMock.Verify(
            x => x.Add(It.Is<User>(x => x.Id == userDto.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloAlreadyExistsException_WhenLoginIsNotUnique()
    {
        //Arrange 
        var command = new AddUserCommand()
        {
            FirstName = "Maciej",
            LastName = "Malek",
            Email = "mm99@gmail.com",
            Login = "mm99",
            Password = "password",
            TypeOfUser = "Operator"
        };

        _userRepositoryMock.Setup(
            x => x.Add(It.IsAny<User>()));

        _userRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new AddUserCommandHandler(
            _userRepositoryMock.Object,
            _mapper,
            _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<UserIsAlreadyExistException>(async () => await handler.Handle(command, default));
    }
}

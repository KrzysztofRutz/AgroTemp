using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Users.GetUserById;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.User;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using FluentAssertions;

namespace AgroTemp.UnitTests.Queries.Users.GetUserById;

public class GetUserByIdQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandlerTests()
    {
        _userRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new UserMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetByIdAsyncOnRepository_WhenGetUserByIdQuery()
    {
        //Arrange
        _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var handler = new GetUserByIdQueryHandler(_userRepositoryMock.Object, _mapper);

        //Act
        await handler.Handle(new GetUserByIdQuery(It.IsAny<int>()), default);

        //Assert
        _userRepositoryMock.Verify(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ReturnUser_WhenUserByIdQuery()
    {
        //Arrange
        var user = new User()
        {
            Id = 1,
            FirstName = "Krzysztof",
            LastName = "Rutz",
            Email = "kr99@o2.pl",
            Login = "KR99",
            Password = "Password0101",
            TypeOfUser = TypeOfUser.Operator,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(user);

        var handler = new GetUserByIdQueryHandler(_userRepositoryMock.Object, _mapper);

        //Act
        var userDto = await handler.Handle(new GetUserByIdQuery(user.Id), default);

        //Assert
        userDto.Should().NotBeNull();
        userDto.FirstName.Should().Be(user.FirstName);
        userDto.LastName.Should().Be(user.LastName);
        userDto.Email.Should().Be(user.Email);
        userDto.Login.Should().Be(user.Login);
        userDto.Password.Length.Should().Be(user.Password.Length); //Because userDto has conversion chars on string to '*'.
        userDto.TypeOfUser.Should().Be(user.TypeOfUser.ToString());
    }

    [Fact]
    public async Task Handle_Should_ThrowUserNotFoundException_WhenUserByIdQuery()
    {
        //Arrange
        _userRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()));

        var handler = new GetUserByIdQueryHandler(_userRepositoryMock.Object, _mapper);

        //Act & Assert
        await Assert.ThrowsAsync<UserNotFoundException>(async () => await handler.Handle(new GetUserByIdQuery(It.IsAny<int>()), default));
    }
}

using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Silos.GetSilos;
using AgroTemp.Application.Queries.Users.GetUsers;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Enums.User;
using AutoMapper;
using FluentAssertions;

namespace AgroTemp.UnitTests.Queries.Users.GetUsers;

public class GetUsersQueryHandlerTests
{
    private readonly Mock<IUserReadOnlyRepository> _userReadOnlyRepositoryMock;
    private readonly IMapper _mapper;

    public GetUsersQueryHandlerTests()
    {
        _userReadOnlyRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new UserMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetAllAsyncOnRepository_WhenGetUsersQuery()
    {
        //Arrange
        _userReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>())).
                ReturnsAsync(Enumerable.Empty<User>);

        var handler = new GetUsersQueryHandler(
            _userReadOnlyRepositoryMock.Object,
            _mapper);

        // Act
        await handler.Handle(new GetUsersQuery(), default);

        // Assert
        _userReadOnlyRepositoryMock.Verify(
           x => x.GetAllAsync(
           It.IsAny<CancellationToken>()),
           Times.Once
           );
    }

    [Fact]
    public async Task Handle_Should_ReturnNotEmptyCollection_WhenGetUsersQuery()
    {
        //Arrange
        var users = new List<User>()
        {
            new User()
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
            },
            new User()
            {
                Id = 2,
                FirstName = "Krzysztof",
                LastName = "Malczewski",
                Email = "km02@o2.pl",
                Login = "Km01",
                Password = "Qwerty1234",
                TypeOfUser = TypeOfUser.Manager,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        };

        _userReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);

        var handler = new GetUsersQueryHandler(_userReadOnlyRepositoryMock.Object, _mapper);

        //Act
        var usersDto = await handler.Handle(new GetUsersQuery(), default);

        //Assert
        usersDto.Should().NotBeNullOrEmpty();
    }
}

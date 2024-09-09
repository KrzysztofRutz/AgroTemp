using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Silos.GetSilos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace AgroTemp.UnitTests.Queries.Silos.GetSilos;

public class GetSilosQueryHandlertests
{
    private readonly Mock<ISiloReadOnlyRepository> _siloReadOnlyRepositoryMock;
    private readonly IMapper _mapper;

    public GetSilosQueryHandlertests()
    {
        _siloReadOnlyRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new SiloMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetAllAsyncOnRepository_WhenGetSilosQuery()
    {
        //Arrange
        _siloReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>())).
                ReturnsAsync(Enumerable.Empty<Silo>);

        var handler = new GetSilosQueryHandler(
            _siloReadOnlyRepositoryMock.Object,
            _mapper);

        // Act
        await handler.Handle(new GetSilosQuery(), default);

        // Assert
        _siloReadOnlyRepositoryMock.Verify(
           x => x.GetAllAsync(
           It.IsAny<CancellationToken>()),
           Times.Once
           );
    }

    [Fact]
    public async Task Handle_Should_ReturnNotEmptyCollection_WhenGetSilosQuery()
    {
        //Arrange
        var silos = new List<Silo>()
        {
            new Silo()
            {
                Id = 1,
                Name = "Z1",
                Size = 100,
                PositionX = 1,
                PositionY = 1,
                OrderSensors = "FromUp",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Silo()
            {
                Id = 2,
                Name = "Z2",
                Size = 100,
                PositionX = 2,
                PositionY = 1,
                OrderSensors = "FromDown",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
        };

        _siloReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(silos);

        var handler = new GetSilosQueryHandler(_siloReadOnlyRepositoryMock.Object, _mapper);

        //Act
        var silosDto = await handler.Handle(new GetSilosQuery(), default);

        //Assert
        silosDto.Should().NotBeNullOrEmpty();
    }
}

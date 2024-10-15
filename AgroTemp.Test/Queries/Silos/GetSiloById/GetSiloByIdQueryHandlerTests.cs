using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Silos.GetSiloById;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using FluentAssertions;

namespace AgroTemp.UnitTests.Queries.Silos.GetSiloById;

public class GetSiloByIdQueryHandlerTests
{
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    private readonly IMapper _mapper;

    public GetSiloByIdQueryHandlerTests()
    {
        _siloRepositoryMock = new Mock<ISiloRepository>();
        _mapper = MapperHelper.CreateMapper(new SiloMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetByIdAsyncOnRepository_WhenGetSiloByIdQuery()
    {
        //Arrange
        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo());

        var handler = new GetSiloByIdQueryHandler(_siloRepositoryMock.Object, _mapper);

        //Act
        await handler.Handle(new GetSiloByIdQuery(It.IsAny<int>()), default);

        //Assert
        _siloRepositoryMock.Verify(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ReturnSilo_WhenSiloByIdQuery()
    {
        //Arrange
        var silo = new Silo()
        {
            Id = 1,
            Name = "Z1",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = OrderSensors.FromDown,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(silo);

        var handler = new GetSiloByIdQueryHandler(_siloRepositoryMock.Object, _mapper);

        //Act
        var siloDto = await handler.Handle(new GetSiloByIdQuery(silo.Id), default);

        //Assert
        siloDto.Should().NotBeNull();
        siloDto.Id.Should().Be(silo.Id);
        siloDto.Name.Should().Be(silo.Name);
        siloDto.Size.Should().Be(silo.Size);
        siloDto.PositionX.Should().Be(silo.PositionX);
        siloDto.PositionY.Should().Be(silo.PositionY);
        siloDto.OrderSensors.Should().Be(silo.OrderSensors.ToString());
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloNotFoundException_WhenSiloByIdQuery()
    {
        //Arrange
        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()));

        var handler = new GetSiloByIdQueryHandler(_siloRepositoryMock.Object, _mapper);

        //Act & Assert
        await Assert.ThrowsAsync<SiloNotFoundException>(async() => await handler.Handle(new GetSiloByIdQuery(It.IsAny<int>()), default));
    }
}

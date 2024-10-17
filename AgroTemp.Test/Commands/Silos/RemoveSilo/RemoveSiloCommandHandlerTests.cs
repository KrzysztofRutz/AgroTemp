using AgroTemp.Application.Commands.Silos.RemoveSilo;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.UnitTests.Commands.Silos.RemoveSilo;

public class RemoveSiloCommandHandlerTests
{
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    private readonly Mock<IExtremeValuesRepository> _extremeValuesRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    public RemoveSiloCommandHandlerTests()
    {
        _siloRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_CallDeleteOnRepository_WhenSiloIsExist()
    {
        //Arrange
        var silo = new Silo
        {
            Id = 1,
            Name = "test",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = OrderSensors.FromUp
        };

        _siloRepositoryMock.Setup(
            x => x.Add(silo));

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                silo.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(silo);

        var command = new RemoveSiloCommand(silo.Id);

        var handler = new RemoveSiloCommandHandler(_siloRepositoryMock.Object, _extremeValuesRepositoryMock.Object, _unitOfWorkMock.Object);
        
        //Act
        await handler.Handle(command, default);

        //Assert
        _siloRepositoryMock.Verify(x => x.Delete(It.Is<Silo>(x => x.Id == silo.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloNotFoundException_WhenSiloIsNotExists()
    {
        //Arrange
        var silo = new Silo
        {
            Id = 1,
            Name = "test",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = OrderSensors.FromUp
        };

        _siloRepositoryMock.Setup(
            x => x.Add(silo));

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                silo.Id,
                It.IsAny<CancellationToken>()));

        var command = new RemoveSiloCommand(silo.Id);

        var handler = new RemoveSiloCommandHandler(_siloRepositoryMock.Object, _extremeValuesRepositoryMock.Object, _unitOfWorkMock.Object);

        //Assert
        await Assert.ThrowsAsync<SiloNotFoundException>(async () => await handler.Handle(command, default));
    }
}

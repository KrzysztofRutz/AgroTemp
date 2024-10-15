using AgroTemp.Application.Commands.Silos.UpdateSilo;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;
using Moq;

namespace AgroTemp.UnitTests.Commands.Silos.UpdateSilo;

public class UpdateSiloCommandHandlerTests
{
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UpdateSiloCommandHandlerTests()
    {
        _siloRepositoryMock = new Mock<ISiloRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    [Fact]
    public async Task Handler_Should_CallUpdateOnRepository_WhenSiloIsExists()
    {
        //Arrange
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Jan",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = "FromDown",
        };

        _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Silo()
            {
                Id = command.Id,
                Name = "Maciej",
                Size = 200,
                PositionX = 2,
                PositionY = 2,
                OrderSensors = OrderSensors.FromDown,
            });

        var handler = new UpdateSiloCommandHandler(
            _siloRepositoryMock.Object, 
            _unitOfWorkMock.Object);

        //Act
        await handler.Handle(command, default);

        //Assert
        _siloRepositoryMock.Verify(
            x => x.Update(It.Is<Silo>(x => x.Id == command.Id)),
            Times.Once);       
    }

    [Fact]
    public async Task Handler_Should_ThrowSiloNotFoundException_WhenSiloIsNotExists()
    {
        //Arrange
        var command = new UpdateSiloCommand
        {
            Id = 1,
            Name = "Jan",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = "FromDown",
        };

        var result = _siloRepositoryMock.Setup(
            x => x.GetByIdAsync(
                command.Id,
                It.IsAny<CancellationToken>()));

        var handler = new UpdateSiloCommandHandler(
            _siloRepositoryMock.Object,
            _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<SiloNotFoundException>(async () => await handler.Handle(command, default));
    }
}

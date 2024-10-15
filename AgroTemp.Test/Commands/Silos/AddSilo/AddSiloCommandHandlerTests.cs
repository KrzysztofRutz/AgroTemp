using AgroTemp.Application.Commands.Silos.AddSilo;
using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using Moq;

namespace AgroTemp.UnitTests.Commands.Silos.AddSilo;

public class AddSiloCommandHandlerTests
{
    private readonly Mock<ISiloRepository> _siloRepositoryMock;
    private readonly Mock<IExtremeValuesRepository> _extremeValuesRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;
    public AddSiloCommandHandlerTests()
    {
        _siloRepositoryMock = new();
        _extremeValuesRepositoryMock = new();  
        _unitOfWorkMock = new();
        _mapper = MapperHelper.CreateMapper(new SiloMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenNameIsUnique()
    {
        //Arrange 
        var command = new AddSiloCommand()
        {
            Name = "Z1",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = "FromUp",
        };

        _siloRepositoryMock.Setup(
            x => x.Add(It.IsAny<Silo>()));

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new AddSiloCommandHandler(
            _siloRepositoryMock.Object,
            _extremeValuesRepositoryMock.Object,
            _mapper,
            _unitOfWorkMock.Object);

        //Act
        var siloDto = await handler.Handle(command, default);

        //Assert 
        _siloRepositoryMock.Verify(
            x => x.Add(It.Is<Silo>(x => x.Id == siloDto.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowSiloAlreadyExistsException_WhenNameIsNotUnique()
    {
        //Arrange 
        var command = new AddSiloCommand()
        {
            Name = "Jan",
            Size = 100,
            PositionX = 1,
            PositionY = 1,
            OrderSensors = "FromUp",
        };

        _siloRepositoryMock.Setup(
            x => x.Add(It.IsAny<Silo>()));

        _siloRepositoryMock.Setup(
            x => x.IsAlreadyExistAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new AddSiloCommandHandler(
            _siloRepositoryMock.Object,
            _extremeValuesRepositoryMock.Object,
            _mapper,
            _unitOfWorkMock.Object);

        //Act & Assert
        await Assert.ThrowsAsync<SiloIsAlreadyExistException>(async () => await handler.Handle(command, default));        
    }
}

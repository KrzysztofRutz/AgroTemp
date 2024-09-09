using AgroTemp.Application.Commands.ReadingModules.AddReadingModule;
using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using Moq;

namespace AgroTemp.UnitTests.Commands.ReadingModules.AddReadingModule;

public class AddReadingModuleCommandHandlerTests
{
    private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;

    public AddReadingModuleCommandHandlerTests()
    {
        _readingModuleRepositoryMock = new Mock<IReadingModuleRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapper = MapperHelper.CreateMapper(new ReadingModuleMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenNameIsUnique()
	{
        //Arrange
        var command = new AddReadingModuleCommand()
        {
            Name = "WC1",
            CommunicationType = "TCP",
            Port_or_AddressIP = "192.168.0.222",
            ModuleID = 1,
            Baudrate = 9600,
            BitsOfSign = 8,
            StopBit = 1,
            ModuleType = "Elecso",
        };

		_readingModuleRepositoryMock.Setup(
			x => x.Add(It.IsAny<ReadingModule>()));

		_readingModuleRepositoryMock.Setup(
			x => x.IsAlreadyExistAsync(
				It.IsAny<string>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(false);

		var handler = new AddReadingModuleCommandHandler(_readingModuleRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

        //Act
        var readingModuleDto = await handler.Handle(command, default);

        //Assert
        _readingModuleRepositoryMock.Verify(
			x => x.Add(It.Is<ReadingModule>(x => x.Name == readingModuleDto.Name)),
			Times.Once);
	}

	[Fact]
	public async Task Handle_Should_CallAddOnRepository_WhenNameIsNotUnique()
	{
		//Arrange
		var command = new AddReadingModuleCommand()
		{
			Name = "WC1",
			CommunicationType = "TCP",
			Port_or_AddressIP = "192.168.0.222",
			ModuleID = 1,
			Baudrate = 9600,
			BitsOfSign = 8,
			StopBit = 1,
			ModuleType = "Elecso",
		};

		_readingModuleRepositoryMock.Setup(
			x => x.Add(It.IsAny<ReadingModule>()));

		_readingModuleRepositoryMock.Setup(
			x => x.IsAlreadyExistAsync(
				It.IsAny<string>(),
				It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

		var handler = new AddReadingModuleCommandHandler(_readingModuleRepositoryMock.Object, _mapper, _unitOfWorkMock.Object);

		//Act & Assert
		await Assert.ThrowsAsync<ReadingModuleIsAlreadyExistException>(async () => await handler.Handle(command, default));
	}
}

using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.ReadingModules.GetReadingModuleById;
using AgroTemp.Application.Queries.Silos.GetSiloById;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using FluentAssertions;
using System.IO.Ports;

namespace AgroTemp.UnitTests.Queries.ReadingModules.GetReadingModuleById;

public class GetReadingModuleByIdQueryHandlerTests
{
    private readonly Mock<IReadingModuleRepository> _readingModuleRepositoryMock;
    private readonly IMapper _mapper;
    public GetReadingModuleByIdQueryHandlerTests()
    {
        _readingModuleRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new ReadingModuleMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetByIdAsyncOnRepository_WhenGetReadingModuleByIdQuery()
    {
        //Arrange
        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ReadingModule());

        var handler = new GetReadingModuleByIdQueryHandler(_readingModuleRepositoryMock.Object, _mapper);

        //Act
        await handler.Handle(new GetReadingModuleByIdQuery(It.IsAny<int>()), default);

        //Assert
        _readingModuleRepositoryMock.Verify(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ReturnReadingModule_WhenReadingModuleByIdQuery()
    {
        //Arrange
        var readingModule = new ReadingModule()
        {
            Id = 1,
            Name = "RM1",
            CommunicationType = CommunicationType.RTU,
            Port_or_AddressIP = "COM1",
            ModuleID = 1,
            Baudrate = Baudrate.bs9600,
            BitsOfSign = 8,
            Parity = Parity.None,
            StopBit = StopBits.One,
            ModuleType = ModuleType.Elecso
        };

        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(readingModule);

        var handler = new GetReadingModuleByIdQueryHandler(_readingModuleRepositoryMock.Object, _mapper);

        //Act
        var readingModuleDto = await handler.Handle(new GetReadingModuleByIdQuery(readingModule.Id), default);

        //Assert
        readingModuleDto.Should().NotBeNull();
        readingModuleDto.Id.Should().Be(readingModule.Id);
        readingModuleDto.Name.Should().Be(readingModule.Name);
        readingModuleDto.CommunicationType.Should().Be(readingModule.CommunicationType.ToString());
        readingModuleDto.Port_or_AddressIP.Should().Be(readingModule.Port_or_AddressIP);
        readingModuleDto.ModuleID.Should().Be(readingModule.ModuleID);
        readingModuleDto.Baudrate.Should().Be((int)readingModule.Baudrate);
        readingModuleDto.BitsOfSign.Should().Be(readingModule.BitsOfSign);
        readingModuleDto.Parity.Should().Be(readingModule.Parity.ToString());
        readingModuleDto.StopBit.Should().Be((int)readingModule.StopBit);
        readingModuleDto.ModuleType.Should().Be(readingModule.ModuleType.ToString());
    }

    [Fact]
    public async Task Handle_Should_ThrowReadingModuleNotFoundException_WhenReadingModuleByIdQuery()
    {
        //Arrange
        _readingModuleRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()));

        var handler = new GetReadingModuleByIdQueryHandler(_readingModuleRepositoryMock.Object, _mapper);

        //Act & Assert
        await Assert.ThrowsAsync<ReadingModuleNotFoundException>(async () => await handler.Handle(new GetReadingModuleByIdQuery(It.IsAny<int>()), default));
    }
}

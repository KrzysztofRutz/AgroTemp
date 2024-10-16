using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.ReadingModules.GetReadingModules;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AutoMapper;
using FluentAssertions;
using System.IO.Ports;

namespace AgroTemp.UnitTests.Queries.ReadingModules.GetReadingModules;

public class GetReadingModulesQueryHandlerTests
{
    private readonly Mock<IReadingModuleReadOnlyRepository> _readingModuleReadOnlyRepositoryMock;
    private readonly IMapper _mapper;

    public GetReadingModulesQueryHandlerTests()
    {
        _readingModuleReadOnlyRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new ReadingModuleMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetAllAsyncOnRepository_WhenGetReadingModulesQuery()
    {
        //Arrange
        _readingModuleReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>())).
                ReturnsAsync(Enumerable.Empty<ReadingModule>);

        var handler = new GetReadingModulesQueryHandler(
            _readingModuleReadOnlyRepositoryMock.Object,
            _mapper);

        // Act
        await handler.Handle(new GetReadingModulesQuery(), default);

        // Assert
        _readingModuleReadOnlyRepositoryMock.Verify(
           x => x.GetAllAsync(
           It.IsAny<CancellationToken>()),
           Times.Once
           );
    }

    [Fact]
    public async Task Handle_Should_ReturnNotEmptyCollection_WhenGetReadingModulesQuery()
    {
        //Arrange
        var readingModules = new List<ReadingModule>()
        {
            new ReadingModule()
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
            },
            new ReadingModule()
            {
                Id = 2,
                Name = "RM2",
                CommunicationType = CommunicationType.RTU,
                Port_or_AddressIP = "COM1",
                ModuleID = 2,
                Baudrate = Baudrate.bs9600,
                BitsOfSign = 8,
                Parity = Parity.None,
                StopBit = StopBits.One,
                ModuleType = ModuleType.Elecso
            },
        };

        _readingModuleReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(readingModules);

        var handler = new GetReadingModulesQueryHandler(_readingModuleReadOnlyRepositoryMock.Object, _mapper);

        //Act
        var readingModulesDto = await handler.Handle(new GetReadingModulesQuery(), default);

        //Assert
        readingModulesDto.Should().NotBeNullOrEmpty();
    }
}

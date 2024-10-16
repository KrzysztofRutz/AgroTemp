using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.ExtremeValues.GetExtremeValues;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;
using FluentAssertions;

namespace AgroTemp.UnitTests.Queries.ExtremeValues.GetExtremeValues;

public class GetExtremeValuesQueryHandlerTests
{
    private readonly Mock<IExtremeValuesReadOnlyRepository> _extremeValuesReadOnlyRepositoryMock;
    private readonly IMapper _mapper;

    public GetExtremeValuesQueryHandlerTests()
    {
        _extremeValuesReadOnlyRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new ExtremeValuesMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetAllAsyncOnRepository_WhenGetExtremeValuesQuery()
    {
        //Arrange
        _extremeValuesReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>())).
                ReturnsAsync(Enumerable.Empty<Domain.Entities.ExtremeValues>);

        var handler = new GetExtremeValuesQueryHandler(
            _extremeValuesReadOnlyRepositoryMock.Object,
            _mapper);

        // Act
        await handler.Handle(new GetExtremeValuesQuery(), default);

        // Assert
        _extremeValuesReadOnlyRepositoryMock.Verify(
           x => x.GetAllAsync(
           It.IsAny<CancellationToken>()),
           Times.Once
           );
    }

    [Fact]
    public async Task Handle_Should_ReturnNotEmptyCollection_WhenGetExtremeValuesQuery()
    {
        //Arrange
        var extremeValues = new List<Domain.Entities.ExtremeValues>()
        {
            new Domain.Entities.ExtremeValues()
            {
                Id = 1,
                MaxTemperature = 10,
                MinTemperature = 5,
                MaxDeltaTemperature = 5,
                SiloId = 1,
                CreatedAt = DateTime.Now,
            },
            new Domain.Entities.ExtremeValues()
            {
                Id = 2,
                MaxTemperature = 10,
                MinTemperature = 5,
                MaxDeltaTemperature = 5,
                SiloId = 2,
                CreatedAt = DateTime.Now,
            },
        };

        _extremeValuesReadOnlyRepositoryMock.Setup(
            x => x.GetAllAsync(
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(extremeValues);

        var handler = new GetExtremeValuesQueryHandler(_extremeValuesReadOnlyRepositoryMock.Object, _mapper);

        //Act
        var extremeValuesDto = await handler.Handle(new GetExtremeValuesQuery(), default);

        //Assert
        extremeValuesDto.Should().NotBeNullOrEmpty();
    }
}

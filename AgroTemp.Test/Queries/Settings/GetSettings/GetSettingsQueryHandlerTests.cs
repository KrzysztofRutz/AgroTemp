using AgroTemp.Application.Configuration.Mappings;
using AgroTemp.Application.Queries.Settings.GetSettings;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Settings;
using AutoMapper;
using FluentAssertions;

namespace AgroTemp.UnitTests.Queries.Settings.GetSettings;

public class GetSettingsQueryHandlerTests
{
    private readonly Mock<ISettingsRepository> _settingsRepositoryMock;
    private readonly IMapper _mapper;

    public GetSettingsQueryHandlerTests()
    {
        _settingsRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new SettingsMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetAsyncOnRepository_WhenGetSettingsQuery()
    {
        //Arrange
        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>()));
                

        var handler = new GetSettingsQueryHandler(
            _settingsRepositoryMock.Object,
            _mapper);

        // Act
        await handler.Handle(new GetSettingsQuery(), default);

        // Assert
        _settingsRepositoryMock.Verify(
           x => x.GetAsync(
           It.IsAny<CancellationToken>()),
           Times.Once
           );
    }

    [Fact]
    public async Task Handle_Should_ReturnNotEmpty_WhenGetSettingsQuery()
    {
        //Arrange
        var settings = new Domain.Entities.Settings()
        {
            Id = 1,
            Language = Language.PL,
            HourOfReading = 10,
            FrequencyOfReading = FrequencyOfReading.Every2hours,
            EnableEmailNotificationMode = true,
            EnableSMSNotificationMode = true,   
        };

        _settingsRepositoryMock.Setup(
            x => x.GetAsync(
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(settings);

        var handler = new GetSettingsQueryHandler(_settingsRepositoryMock.Object, _mapper);

        //Act
        var settingsDto = await handler.Handle(new GetSettingsQuery(), default);

        //Assert
        settingsDto.Should().NotBeNull();
    }
}

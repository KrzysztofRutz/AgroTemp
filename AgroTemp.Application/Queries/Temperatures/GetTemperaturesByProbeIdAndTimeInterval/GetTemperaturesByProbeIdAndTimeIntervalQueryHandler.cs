using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Application.Queries.Temperatures.GetTemperaturesByTimeInterval;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Temperatures.GetTemperaturesByProbeIdAndTimeInterval;

public class GetTemperaturesByProbeIdAndTimeIntervalQueryHandler : IQueryHandler<GetTemperaturesByProbeIdAndTimeIntervalQuery, IEnumerable<TemperatureByIntervalTimeDto>>
{
    private readonly ITemperatureRepository _temperatureRepository;
    private readonly IProbeRepository _probeRepository;
    private readonly ISettingsRepository _settingsRepository;
    private readonly IMapper _mapper;

    public GetTemperaturesByProbeIdAndTimeIntervalQueryHandler(ITemperatureRepository temperatureRepository, IProbeRepository probeRepository, ISettingsRepository settingsRepository, IMapper mapper)
    {
        _temperatureRepository = temperatureRepository;
        _probeRepository = probeRepository;
        _settingsRepository = settingsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TemperatureByIntervalTimeDto>> Handle(GetTemperaturesByProbeIdAndTimeIntervalQuery request, CancellationToken cancellationToken)
    {
        var probe = await _probeRepository.GetByIdAsync(request.probeId);

        if (probe == null)
        {
            throw new ProbeNotFoundException(request.probeId);
        }

        var settings = await _settingsRepository.GetAsync(cancellationToken);

        var temperatures = await _temperatureRepository.GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(probe.ReadingModuleId, request.startDateTime, request.endDateTime, settings.HourOfReading, settings.FrequencyOfReading, cancellationToken);

        var temperaturesByIntervalTimeDto = _mapper.Map<IEnumerable<TemperatureByIntervalTimeDto>>(temperatures);

        foreach (var temperature in temperaturesByIntervalTimeDto)
        {
            temperature.ListOfTemperatures = temperature.ListOfTemperatures.Skip(probe.NrFirstSensor - 1).Take(probe.SensorsCount).ToList();
        }

        return temperaturesByIntervalTimeDto;
    }
}

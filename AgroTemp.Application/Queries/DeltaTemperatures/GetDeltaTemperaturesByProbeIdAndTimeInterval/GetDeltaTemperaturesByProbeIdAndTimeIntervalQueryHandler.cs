using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using MediatR;

namespace AgroTemp.Application.Queries.DeltaTemperatures.GetDeltaTemperaturesByProbeIdAndTimeInterval;

public class GetDeltaTemperaturesByProbeIdAndTimeIntervalQueryHandler : IQueryHandler<GetDeltaTemperaturesByProbeIdAndTimeIntervalQuery, IEnumerable<DeltaTemperatureByIntervalTimeDto>>
{
    private readonly IDeltaTemperatureRepository _deltaTemperatureRepository;
    private readonly IProbeRepository _probeRepository;
    private readonly ISettingsRepository _settingsRepository;
    private readonly IMapper _mapper;
    public GetDeltaTemperaturesByProbeIdAndTimeIntervalQueryHandler(IDeltaTemperatureRepository deltaTemperatureRepository, IProbeRepository probeRepository, ISettingsRepository settingsRepository, IMapper mapper)
    {
        _deltaTemperatureRepository = deltaTemperatureRepository;
        _probeRepository = probeRepository;
        _settingsRepository = settingsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DeltaTemperatureByIntervalTimeDto>> Handle(GetDeltaTemperaturesByProbeIdAndTimeIntervalQuery request, CancellationToken cancellationToken)
    {
        var probe = await _probeRepository.GetByIdAsync(request.probeId);

        if (probe == null)
        {
            throw new ProbeNotFoundException(request.probeId);
        }

        var settings = await _settingsRepository.GetAsync(cancellationToken);

        var deltaTemperatures = await _deltaTemperatureRepository.GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(probe.ReadingModuleId, request.startDateTime, request.endDateTime, settings.HourOfReading, cancellationToken);

        var deltaTemperaturesByIntervalTimeDto = _mapper.Map<IEnumerable<DeltaTemperatureByIntervalTimeDto>>(deltaTemperatures);

        foreach (var delta in deltaTemperaturesByIntervalTimeDto)
        {
            delta.ListOfTemperatures = delta.ListOfTemperatures.Skip(probe.NrFirstSensor - 1).Take(probe.SensorsCount).ToList();
        }

        return deltaTemperaturesByIntervalTimeDto;
    }
}


using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.Probes.GetProbesWithDetails;

public class GetProbesWithDetailsQueryHandler : IQueryHandler<GetProbesWithDetailsQuery, IEnumerable<ProbeWithDetailsDto>>
{
    private readonly IProbeReadOnlyRepository _probeReadOnlyRepository;
    private readonly ITemperatureRepository _temperatureRepository;
    private readonly IDeltaTemperatureRepository _deltaTemperatureRepository;
    private readonly IMapper _mapper;

    public GetProbesWithDetailsQueryHandler(IProbeReadOnlyRepository probeReadOnlyRepository, ITemperatureRepository temperatureRepository, IDeltaTemperatureRepository deltaTemperatureRepository, IMapper mapper)
    {
        _probeReadOnlyRepository = probeReadOnlyRepository;
        _temperatureRepository = temperatureRepository;
        _deltaTemperatureRepository = deltaTemperatureRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProbeWithDetailsDto>> Handle(GetProbesWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var probes = await _probeReadOnlyRepository.GetAllWithDetailsAsync(cancellationToken);

        var probesWithDetailsDto = _mapper.Map<IEnumerable<ProbeWithDetailsDto>>(probes);

        foreach (var probe in probesWithDetailsDto)
        {
            var temperature = await _temperatureRepository.GetActualMeasureByReadingModuleIdAsync(probe.ReadingModule.Id);
            var deltaTemperature = await _deltaTemperatureRepository.GetActualMeasureByReadingModuleIdAsync(probe.ReadingModule.Id);

            if (temperature != null)
            {
                var temperatureForOneProbeDto = _mapper.Map<TemperatureForOneProbeDto>(temperature);
                probe.ActualTemperatures = temperatureForOneProbeDto.ListOfValues.Skip(probe.NrFirstSensor - 1).Take(probe.SensorsCount).ToList();

            }

            if (deltaTemperature != null)
            {
                var deltaTemperatureForOneProbeDto = _mapper.Map<DeltaTemperatureForOneProbeDto>(deltaTemperature);

                probe.ActualDeltaTemperatures = deltaTemperatureForOneProbeDto.ListOfValues.Skip(probe.NrFirstSensor - 1).Take(probe.SensorsCount).ToList();
            }
        }

        return probesWithDetailsDto;
    }
}

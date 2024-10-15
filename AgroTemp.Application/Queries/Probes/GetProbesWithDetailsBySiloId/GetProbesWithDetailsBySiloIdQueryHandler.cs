using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Abstractions;
using AutoMapper;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Queries.Probes.GetProbesWithDetailsBySiloId;

public class GetProbesWithDetailsBySiloIdQueryHandler : IQueryHandler<GetProbesWithDetailsBySiloIdQuery, IEnumerable<ProbeWithDetailsDto>>
{
    private readonly IProbeReadOnlyRepository _probeReadOnlyRepository;
    private readonly ITemperatureRepository _temperatureRepository;
    private readonly IDeltaTemperatureRepository _deltaTemperatureRepository;
    private readonly IMapper _mapper;
    private readonly ISiloRepository _siloRepository;

    public GetProbesWithDetailsBySiloIdQueryHandler(IProbeReadOnlyRepository probeReadOnlyRepository, ITemperatureRepository temperatureRepository, IDeltaTemperatureRepository deltaTemperatureRepository, ISiloRepository siloRepository, IMapper mapper)
    {
        _probeReadOnlyRepository = probeReadOnlyRepository;
        _temperatureRepository = temperatureRepository;
        _deltaTemperatureRepository = deltaTemperatureRepository;
        _siloRepository = siloRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProbeWithDetailsDto>> Handle(GetProbesWithDetailsBySiloIdQuery request, CancellationToken cancellationToken)
    {
        var silo = await _siloRepository.GetByIdAsync(request.siloId);

        if (silo == null)
        {
            throw new SiloNotFoundException(request.siloId);
        }

        var probes = await _probeReadOnlyRepository.GetWithDetailsBySiloIdAsync(request.siloId ,cancellationToken);

        var probesWithDetailsDto = _mapper.Map<IEnumerable<ProbeWithDetailsDto>>(probes);

        foreach (var probe in probesWithDetailsDto)
        {
            var temperature = await _temperatureRepository.GetActualMeasureByReadingModuleIdAsync(probe.ReadingModule.Id);
            var deltaTemperature = await _deltaTemperatureRepository.GetActualMeasureByReadingModuleIdAsync(probe.ReadingModule.Id);

            if (temperature != null)
            {
                var temperatureForOneProbeDto = _mapper.Map<TemperatureForOneProbeDto>(temperature);
                probe.ActualTemperatures = temperatureForOneProbeDto.ListOfTemperatures.Skip(probe.NrFirstSensor - 1).Take(probe.SensorsCount).ToList();

            }

            if (deltaTemperature != null)
            {
                var deltaTemperatureForOneProbeDto = _mapper.Map<DeltaTemperatureForOneProbeDto>(deltaTemperature);

                probe.ActualDeltaTemperatures = deltaTemperatureForOneProbeDto.ListOfDeltaTemperatures.Skip(probe.NrFirstSensor - 1).Take(probe.SensorsCount).ToList();
            }
        }

        return probesWithDetailsDto;
    }
}

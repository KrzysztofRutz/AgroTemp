using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Probes.GetProbesBySiloId;

public class GetProbesBySiloIdQueryHandler : IQueryHandler<GetProbesBySiloIdQuery, IEnumerable<ProbeDto>>
{
    private readonly IProbeRepository _probeRepository;
    private readonly ISiloRepository _siloRepository;
    private readonly IMapper _mapper;

    public GetProbesBySiloIdQueryHandler(IProbeRepository probeRepository, ISiloRepository siloRepository, IMapper mapper)
    {
        _probeRepository = probeRepository;
        _siloRepository = siloRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProbeDto>> Handle(GetProbesBySiloIdQuery request, CancellationToken cancellationToken)
    {
        var silo = await _siloRepository.GetByIdAsync(request.siloId);

        if (silo == null)
        {
            throw new SiloNotFoundException(request.siloId);
        }

        var probes = await _probeRepository.GetBySiloIdAsync(request.siloId, cancellationToken);

        var probesDto = _mapper.Map<IEnumerable<ProbeDto>>(probes);

        return probesDto;
    }
}

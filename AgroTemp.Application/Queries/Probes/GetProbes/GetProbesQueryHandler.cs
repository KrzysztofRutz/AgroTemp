using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Queries.Probes.GetProbes;

public class GetProbesQueryHandler : IQueryHandler<GetProbesQuery, IEnumerable<ProbeDto>>
{
    private readonly IProbeReadOnlyRepository _probeReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetProbesQueryHandler(IProbeReadOnlyRepository probeReadOnlyRepository, IMapper mapper)
    {
        _probeReadOnlyRepository = probeReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProbeDto>> Handle(GetProbesQuery request, CancellationToken cancellationToken)
    {
        var probes = await _probeReadOnlyRepository.GetAllAsync(cancellationToken);

        var probesDto = _mapper.Map<IEnumerable<ProbeDto>>(probes);

        return probesDto;
    }
}

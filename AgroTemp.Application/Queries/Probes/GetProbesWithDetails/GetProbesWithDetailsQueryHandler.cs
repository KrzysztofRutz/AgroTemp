using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.Probes.GetProbesWithDetails;

public class GetProbesWithDetailsQueryHandler : IQueryHandler<GetProbesWithDetailsQuery, IEnumerable<ProbeWithDetailsDto>>
{
    private readonly IProbeReadOnlyRepository _probeReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetProbesWithDetailsQueryHandler(IProbeReadOnlyRepository probeReadOnlyRepository, IMapper mapper)
    {
        _probeReadOnlyRepository = probeReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProbeWithDetailsDto>> Handle(GetProbesWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var probes = await _probeReadOnlyRepository.GetAllWithDetailsAsync(cancellationToken);

        var probesDto = _mapper.Map<IEnumerable<ProbeWithDetailsDto>>(probes);

        return probesDto;
    }
}

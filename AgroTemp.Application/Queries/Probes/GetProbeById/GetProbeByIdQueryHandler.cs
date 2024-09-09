using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Probes.GetProbeById;

public class GetProbeByIdQueryHandler : IQueryHandler<GetProbeByIdQuery, ProbeDto>
{
    private readonly IProbeRepository _probeRepository;
    private readonly IMapper _mapper;

    public GetProbeByIdQueryHandler(IProbeRepository probeRepository, IMapper mapper)
    {
        _probeRepository = probeRepository;
        _mapper = mapper;
    }
    public async Task<ProbeDto> Handle(GetProbeByIdQuery request, CancellationToken cancellationToken)
    {
        var probe = await _probeRepository.GetByIdAsync(request.Id);

        if (probe == null)
        {
            throw new ProbeNotFoundException(request.Id);
        }

        var probeDto = _mapper.Map<ProbeDto>(probe);    

        return probeDto;
    }
}

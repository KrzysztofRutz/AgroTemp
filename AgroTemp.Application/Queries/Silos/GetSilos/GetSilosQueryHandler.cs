using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.Silos.GetSilos;

public class GetSilosQueryHandler : IQueryHandler<GetSilosQuery, IEnumerable<SiloDto>>
{
    private readonly ISiloReadOnlyRepository _siloReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetSilosQueryHandler(ISiloReadOnlyRepository siloReadOnlyRepository , IMapper mapper)
    {
        _siloReadOnlyRepository = siloReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SiloDto>> Handle(GetSilosQuery request, CancellationToken cancellationToken)
    {
        var silos = await _siloReadOnlyRepository.GetAllAsync(cancellationToken);

        var silosDto = _mapper.Map<IEnumerable<SiloDto>>(silos);

        return silosDto;
    }
}

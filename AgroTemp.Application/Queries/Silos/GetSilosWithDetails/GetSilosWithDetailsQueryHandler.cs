using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.Silos.GetSilosWithDetails;

public class GetSilosWithDetailsQueryHandler : IQueryHandler<GetSilosWithDetailsQuery, IEnumerable<SiloWithDetailsDto>>
{
    private readonly ISiloReadOnlyRepository _siloReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetSilosWithDetailsQueryHandler(ISiloReadOnlyRepository siloReadOnlyRepository, IMapper mapper)
    {
        _siloReadOnlyRepository = siloReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SiloWithDetailsDto>> Handle(GetSilosWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var silos = await _siloReadOnlyRepository.GetAllWithDetailsAsync(cancellationToken);

        var silosWithDetailsDto = _mapper.Map<IEnumerable<SiloWithDetailsDto>>(silos);

        return silosWithDetailsDto;
    }
}

using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Silos.GetSiloById;

public class GetSiloByIdQueryHandler : IQueryHandler<GetSiloByIdQuery, SiloDto>
{
    private readonly ISiloRepository _siloRepository;
    private readonly IMapper _mapper;

    public GetSiloByIdQueryHandler(ISiloRepository siloRepository, IMapper mapper)
    {
        _siloRepository = siloRepository;
        _mapper = mapper;
    }

    public async Task<SiloDto> Handle(GetSiloByIdQuery request, CancellationToken cancellationToken)
    {
        var silo = await _siloRepository.GetByIdAsync(request.Id, cancellationToken);

        if (silo == null)
        {
            throw new SiloNotFoundException(request.Id);
        }

        var siloDto = _mapper.Map<SiloDto>(silo);

        return siloDto;
    }

    public object Handle(GetSiloByIdQuery getSiloByIdQuery)
    {
        throw new NotImplementedException();
    }
}

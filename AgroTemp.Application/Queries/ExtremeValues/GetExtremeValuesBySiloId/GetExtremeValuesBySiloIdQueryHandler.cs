using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AutoMapper;

namespace AgroTemp.Application.Queries.ExtremeValues.GetExtremeValuesBySiloId;

public class GetExtremeValuesBySiloIdQueryHandler : IQueryHandler<GetExtremeValuesBySiloIdQuery, ExtremeValuesDto>
{
    private readonly IExtremeValuesRepository _extremeValuesRepository;
    private readonly IMapper _mapper;

    public GetExtremeValuesBySiloIdQueryHandler(IExtremeValuesRepository extremeValuesRepository, IMapper mapper)
    {
        _extremeValuesRepository = extremeValuesRepository;
        _mapper = mapper;
    }

    public async Task<ExtremeValuesDto> Handle(GetExtremeValuesBySiloIdQuery request, CancellationToken cancellationToken)
    {
        var extremeValues = await _extremeValuesRepository.GetBySiloIdAsync(request.siloId);

        var extremeValuesDto = _mapper.Map<ExtremeValuesDto>(extremeValues);

        return extremeValuesDto;
    }
}

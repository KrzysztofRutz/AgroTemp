using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.ExtremeValues.GetExtremeValues;

public class GetExtremeValuesQueryHandler : IQueryHandler<GetExtremeValuesQuery, IEnumerable<ExtremeValuesDto>>
{
    private readonly IExtremeValuesReadOnlyRepository _extremeValuesReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetExtremeValuesQueryHandler(IExtremeValuesReadOnlyRepository extremeValuesReadOnlyRepository, IMapper mapper)
    {
        _extremeValuesReadOnlyRepository = extremeValuesReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExtremeValuesDto>> Handle(GetExtremeValuesQuery request, CancellationToken cancellationToken)
    {
        var extremeValues = await _extremeValuesReadOnlyRepository.GetAllAsync(cancellationToken);

        var extremeValuesDto = _mapper.Map<IEnumerable<ExtremeValuesDto>>(extremeValues);

        return extremeValuesDto;
    }
}

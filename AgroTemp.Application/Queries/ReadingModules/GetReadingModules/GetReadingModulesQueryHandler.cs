using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.ReadingModules.GetReadingModules;

public class GetReadingModulesQueryHandler : IQueryHandler<GetReadingModulesQuery, IEnumerable<ReadingModuleDto>>
{
    private readonly IReadingModuleReadOnlyRepository _readingModuleReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetReadingModulesQueryHandler(IReadingModuleReadOnlyRepository readingModuleReadOnlyRepository, IMapper mapper)
    {
        _readingModuleReadOnlyRepository = readingModuleReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadingModuleDto>> Handle(GetReadingModulesQuery request, CancellationToken cancellationToken)
    {
        var readingModules = await _readingModuleReadOnlyRepository.GetAllAsync(cancellationToken);

        var readingModulesDto = _mapper.Map<IEnumerable<ReadingModuleDto>>(readingModules);

        return readingModulesDto;
    }
}

using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Queries.ReadingModules.GetReadingModuleById;

public class GetReadingModuleByIdQueryHandler : IQueryHandler<GetReadingModuleByIdQuery, ReadingModuleDto>
{
    private readonly IReadingModuleRepository _readingModuleRepository;
    private readonly IMapper _mapper;

    public GetReadingModuleByIdQueryHandler(IReadingModuleRepository readingModuleRepository, IMapper mapper)
    {
        _readingModuleRepository = readingModuleRepository;
        _mapper = mapper;
    }

    public async Task<ReadingModuleDto> Handle(GetReadingModuleByIdQuery request, CancellationToken cancellationToken)
    {
        var readingModule = await _readingModuleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (readingModule == null)
        {
            throw new ReadingModuleNotFoundException(request.Id);
        }

        var readingModuleDto = _mapper.Map<ReadingModuleDto>(readingModule);

        return readingModuleDto;
    }
}

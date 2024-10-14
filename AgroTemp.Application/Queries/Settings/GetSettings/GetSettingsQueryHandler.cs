using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Settings.GetSettings;

public class GetSettingsQueryHandler : IQueryHandler<GetSettingsQuery, SettingsDto>
{
    private readonly ISettingsRepository _settingsRepository;
    private readonly IMapper _mapper;

    public GetSettingsQueryHandler(ISettingsRepository settingsRepository, IMapper mapper)
    {
        _settingsRepository = settingsRepository;
        _mapper = mapper;
    }

    public async Task<SettingsDto> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
    {
        var settings = await _settingsRepository.GetAsync(cancellationToken);

        var settingsDto = _mapper.Map<SettingsDto>(settings);

        return settingsDto;
    }
}

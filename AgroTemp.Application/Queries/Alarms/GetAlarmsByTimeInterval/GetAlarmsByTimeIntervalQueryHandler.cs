using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Alarms.GetAlarmsByTimeInterval;

public class GetAlarmsByTimeIntervalQueryHandler : IQueryHandler<GetAlarmsByTimeIntervalQuery, IEnumerable<AlarmDto>>
{
    private readonly IAlarmRepository _alarmRepository;
    private readonly IMapper _mapper;

    public GetAlarmsByTimeIntervalQueryHandler(IAlarmRepository alarmRepository, IMapper mapper)
    {
        _alarmRepository = alarmRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlarmDto>> Handle(GetAlarmsByTimeIntervalQuery request, CancellationToken cancellationToken)
    {
        var alarms = await _alarmRepository.GetAlarmsBetweenCreatedAtAndUpdatedAtAsync(request.startDate, request.endDate, cancellationToken);

        var alarmsDto = _mapper.Map<IEnumerable<AlarmDto>>(alarms);

        return alarmsDto;
    }
}

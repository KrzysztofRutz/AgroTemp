using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Alarms.GetActiveAlarms;

public class GetActiveAlarmsQueryHandler : IQueryHandler<GetActiveAlarmsQuery, IEnumerable<AlarmDto>>
{
    private readonly IAlarmRepository _alarmRepository;
    private readonly IMapper _mapper;

    public GetActiveAlarmsQueryHandler(IAlarmRepository alarmRepository, IMapper mapper)
    {
        _alarmRepository = alarmRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlarmDto>> Handle(GetActiveAlarmsQuery request, CancellationToken cancellationToken)
    {
        var alarms = await _alarmRepository.GetActiveAlarmsAsync(cancellationToken);

        var alarmsDto = _mapper.Map<IEnumerable<AlarmDto>>(alarms);

        return alarmsDto;
    }
}

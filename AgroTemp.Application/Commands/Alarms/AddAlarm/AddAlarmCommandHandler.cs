using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Alarm;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Alarms.AddAlarm;

public class AddAlarmCommandHandler : ICommandHandler<AddAlarmCommand, AlarmDto>
{
    private readonly IAlarmRepository _alarmRepository;
    private readonly IProbeReadOnlyRepository _probeReadOnlyRepository;
    private readonly IReadingModuleReadOnlyRepository _readingModuleReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddAlarmCommandHandler(IAlarmRepository alarmRepository, IProbeReadOnlyRepository probeReadOnlyRepository, 
        IReadingModuleReadOnlyRepository readingModuleReadOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _alarmRepository = alarmRepository;
        _probeReadOnlyRepository = probeReadOnlyRepository;
        _readingModuleReadOnlyRepository = readingModuleReadOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AlarmDto> Handle(AddAlarmCommand request, CancellationToken cancellationToken)
    {
        var description = (Description)Enum.Parse(typeof(Description), request.Description);

        switch (description)
        {
            case Description.HighTemperature:
            case Description.LowTemperature:
            case Description.HighDeltaTemperature:
                var probes = await _probeReadOnlyRepository.GetAllAsync(cancellationToken);

                if (!probes.Any(x => x.Name == request.ObjectName))
                {
                    throw new ProbeNotFoundException(request.ObjectName);
                }
                break;

            case Description.NoConnectionWithModuleId:
                var readingModules = await _readingModuleReadOnlyRepository.GetAllAsync(cancellationToken);

                if (!readingModules.Any(x => x.Name == request.ObjectName))
                {
                    throw new ReadingModuleNotFoundException(request.ObjectName);
                }
                break;
        }

        var alarm = new Alarm
        {
            Description = description,
            ObjectName = request.ObjectName
        };

        _alarmRepository.Add(alarm);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var alarmDto = _mapper.Map<AlarmDto>(alarm);

        return alarmDto;
    }
}

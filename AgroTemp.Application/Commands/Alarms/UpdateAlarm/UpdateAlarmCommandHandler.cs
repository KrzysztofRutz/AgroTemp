using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Alarms.UpdateAlarm;

public class UpdateAlarmCommandHandler : ICommandHandler<UpdateAlarmCommand>
{
    private readonly IAlarmRepository _alarmRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAlarmCommandHandler(IAlarmRepository alarmRepository, IUnitOfWork unitOfWork)
    {
        _alarmRepository = alarmRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAlarmCommand request, CancellationToken cancellationToken)
    {
        var alarm = await _alarmRepository.GetByIdAsync(request.Id, cancellationToken);

        if (alarm == null)
        {
            throw new AlarmNotFoundException(request.Id);
        }

        _alarmRepository.Update(alarm);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

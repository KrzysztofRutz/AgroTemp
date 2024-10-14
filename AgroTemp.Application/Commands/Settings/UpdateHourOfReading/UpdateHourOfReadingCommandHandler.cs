using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;

namespace AgroTemp.Application.Commands.Settings.UpdateHourOfReading;

public class UpdateHourOfReadingCommandHandler : ICommandHandler<UpdateHourOfReadingCommand>
{
    private readonly ISettingsRepository _settingsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHourOfReadingCommandHandler(ISettingsRepository settingsRepository, IUnitOfWork unitOfWork)
    {
        _settingsRepository = settingsRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateHourOfReadingCommand request, CancellationToken cancellationToken)
    {
        _settingsRepository.UpdateHourOfReading(request.HourOfReading);
        await _unitOfWork.SaveChangesAsync();
    }
}

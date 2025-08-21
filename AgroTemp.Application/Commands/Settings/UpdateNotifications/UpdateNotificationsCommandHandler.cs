using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;

namespace AgroTemp.Application.Commands.Settings.UpdateNotifications;

public class UpdateNotificationsCommandHandler : ICommandHandler<UpdateNotificationsCommand>
{
    private readonly ISettingsRepository _settingsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationsCommandHandler(ISettingsRepository settingsRepository, IUnitOfWork unitOfWork)
    {
        _settingsRepository = settingsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateNotificationsCommand request, CancellationToken cancellationToken)
    {
        _settingsRepository.UpdateSMSNotificationMode(request.IsSMSEnabled);
        _settingsRepository.UpdateEmailNotificationMode(request.IsEmailEnabled);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

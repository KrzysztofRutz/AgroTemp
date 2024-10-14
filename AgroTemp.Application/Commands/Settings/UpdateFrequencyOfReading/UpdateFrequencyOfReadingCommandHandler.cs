using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;

namespace AgroTemp.Application.Commands.Settings.UpdateFrequencyOfReading;

public class UpdateFrequencyOfReadingCommandHandler : ICommandHandler<UpdateFrequencyOfReadingCommand>
{
    private readonly ISettingsRepository _settingsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFrequencyOfReadingCommandHandler(ISettingsRepository settingsRepository, IUnitOfWork unitOfWork)
    {
        _settingsRepository = settingsRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateFrequencyOfReadingCommand request, CancellationToken cancellationToken)
    {
        _settingsRepository.UpdateFrequencyOfReading(request.FrequencyOfReading);
        await _unitOfWork.SaveChangesAsync();
    }
}

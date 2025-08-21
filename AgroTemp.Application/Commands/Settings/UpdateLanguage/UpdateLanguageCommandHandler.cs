using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Application.Commands.Settings.UpdateLanguage;

public class UpdateLanguageCommandHandler : ICommandHandler<UpdateLanguageCommand>
{
    private readonly ISettingsRepository _settingsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLanguageCommandHandler(ISettingsRepository settingsRepository, IUnitOfWork unitOfWork)
    {
        _settingsRepository = settingsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        _settingsRepository.UpdateLanguage((Language)Enum.Parse(typeof(Language), request.Language));
        await _unitOfWork.SaveChangesAsync();
    }
}

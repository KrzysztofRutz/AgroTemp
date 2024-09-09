using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.ReadingModules.RemoveReadingModule;

public class RemoveReadingModuleCommandHandler : ICommandHandler<RemoveReadingModuleCommand>
{
    private readonly IReadingModuleRepository _readingModuleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveReadingModuleCommandHandler(IReadingModuleRepository readingModuleRepository, IUnitOfWork unitOfWork)
    {
        _readingModuleRepository = readingModuleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveReadingModuleCommand request, CancellationToken cancellationToken)
    {
        var readingModule = await _readingModuleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (readingModule == null)
        {
            throw new ReadingModuleNotFoundException(request.Id);
        }

        _readingModuleRepository.Delete(readingModule);
        await _unitOfWork.SaveChangesAsync();
    }
}

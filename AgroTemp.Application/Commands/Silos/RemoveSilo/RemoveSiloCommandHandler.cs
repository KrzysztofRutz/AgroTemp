using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Silos.RemoveSilo;

public class RemoveSiloCommandHandler : ICommandHandler<RemoveSiloCommand>
{
    private readonly ISiloRepository _siloRepository;
    private readonly IExtremeValuesRepository _extremeValuesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveSiloCommandHandler(ISiloRepository siloRepository, IExtremeValuesRepository extremeValuesRepository, IUnitOfWork unitOfWork)
    {
        _siloRepository = siloRepository;
        _extremeValuesRepository = extremeValuesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveSiloCommand request, CancellationToken cancellationToken)
    {
        var silo = await _siloRepository.GetByIdAsync(request.Id, cancellationToken);

        if (silo == null)
        {
            throw new SiloNotFoundException(request.Id);
        }

        var extremeValues = await _extremeValuesRepository.GetBySiloIdAsync(silo.Id, cancellationToken);

        _extremeValuesRepository.Delete(extremeValues);
        _siloRepository.Delete(silo);    
        await _unitOfWork.SaveChangesAsync();
    }
}

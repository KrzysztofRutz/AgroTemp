using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Silos.RemoveSilo;

public class RemoveSiloCommandHandler : ICommandHandler<RemoveSiloCommand>
{
    private readonly ISiloRepository _siloRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveSiloCommandHandler(ISiloRepository siloRepository, IUnitOfWork unitOfWork)
    {
        _siloRepository = siloRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveSiloCommand request, CancellationToken cancellationToken)
    {
        var silo = await _siloRepository.GetByIdAsync(request.Id, cancellationToken);

        if (silo == null)
        {
            throw new SiloNotFoundException(request.Id);
        }

        _siloRepository.Delete(silo);
        await _unitOfWork.SaveChangesAsync();
    }
}

using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Silos.UpdateSilo;

public class UpdateSiloCommandHandler : ICommandHandler<UpdateSiloCommand>
{
    private readonly ISiloRepository _siloRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSiloCommandHandler(ISiloRepository siloRepository, IUnitOfWork unitOfWork)
    {
        _siloRepository = siloRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSiloCommand request, CancellationToken cancellationToken)
    {
        var silo = await _siloRepository.GetByIdAsync(request.Id, cancellationToken);

        if (silo == null)
        {
            throw new SiloNotFoundException(request.Id);
        }

        silo.Name = request.Name;
        silo.Size = request.Size;
        silo.PositionX = request.PositionX;
        silo.PositionY = request.PositionY;
        silo.OrderSensors = (OrderSensors)Enum.Parse(typeof(OrderSensors), request.OrderSensors);

        _siloRepository.Update(silo);
        await _unitOfWork.SaveChangesAsync();
    }
}

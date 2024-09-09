using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Probes.RemoveProbe;

public class RemoveProbeCommandHandler : ICommandHandler<RemoveProbeCommand>
{
    private readonly IProbeRepository _probeRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RemoveProbeCommandHandler(IProbeRepository probeRepository, IUnitOfWork unitOfWork)
    {
        _probeRepository = probeRepository;
		_unitOfWork = unitOfWork;
	}
    public async Task Handle(RemoveProbeCommand request, CancellationToken cancellationToken)
    {
        var probe = await _probeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (probe == null)
        {
            throw new ProbeNotFoundException(request.Id);
        }

        _probeRepository.Delete(probe);
        await _unitOfWork.SaveChangesAsync();
    }
}

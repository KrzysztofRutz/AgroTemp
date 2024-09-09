using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Probes.UpdateProbe;

public class UpdateProbeCommandHandler : ICommandHandler<UpdateProbeCommand>
{
    private readonly IProbeRepository _probeRepository;
	private readonly ISiloRepository _siloRepository;
	private readonly IReadingModuleRepository _readingModuleRepository;
	private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProbeCommandHandler(IProbeRepository probeRepository, ISiloRepository siloRepository, IReadingModuleRepository readingModuleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _probeRepository = probeRepository;
        _siloRepository = siloRepository;
        _readingModuleRepository = readingModuleRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProbeCommand request, CancellationToken cancellationToken)
    {
        var probe = await _probeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (probe == null)
        {
            throw new ProbeNotFoundException(request.Id);
        }

		var silo = await _siloRepository.GetByIdAsync(request.SiloId, cancellationToken);

		if (silo == null)
		{
			throw new SiloNotFoundException(request.SiloId);
		}

		var readingModule = await _readingModuleRepository.GetByIdAsync(request.ReadingModuleId, default);

		if (readingModule == null)
		{
			throw new ReadingModuleNotFoundException(request.ReadingModuleId);
		}

		probe.Name = request.Name;
        probe.SensorsCount = request.SensorsCount;
        probe.NrFirstSensor = request.NrFirstSensor;
        probe.SiloId = request.SiloId;
        probe.ReadingModuleId = request.ReadingModuleId;

        _probeRepository.Update(probe);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

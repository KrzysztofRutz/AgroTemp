using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Probes.AddProbe;

public class AddProbeCommandHandler : ICommandHandler<AddProbeCommand, ProbeDto>
{
    private readonly IProbeRepository _probeRepository;
    private readonly ISiloRepository _siloRepository;
    private readonly IReadingModuleRepository _readingModuleRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddProbeCommandHandler(IProbeRepository probeRepository, ISiloRepository siloRepository, IReadingModuleRepository readingModuleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _probeRepository = probeRepository;
        _siloRepository = siloRepository;
        _readingModuleRepository = readingModuleRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProbeDto> Handle(AddProbeCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _probeRepository.IsAlreadyExistAsync(request.Name, cancellationToken);

        if (isAlreadyExist) 
        {
            throw new ProbeIsAlreadyExistException(request.Name);
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

        var newProbe = new Probe
        {
            Name = request.Name,
            SensorsCount = request.SensorsCount,
            NrFirstSensor = request.NrFirstSensor,
            NrOfCircle = request.NrOfCircle,
            SiloId = request.SiloId,
            ReadingModuleId = request.ReadingModuleId,
        };

        _probeRepository.Add(newProbe);
        await _unitOfWork.SaveChangesAsync();

        var probeDto = _mapper.Map<ProbeDto>(newProbe);

        return probeDto;
    }
}

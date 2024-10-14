using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.DeltaTemperatures.AddDeltaTemperature;

public class AddDeltaTemperatureCommandHandler : ICommandHandler<AddDeltaTemperatureCommand, IEnumerable<DeltaTemperatureDto>>
{
    private readonly IDeltaTemperatureRepository _deltaTemperatureRepository;
    private readonly IReadingModuleReadOnlyRepository _readingModuleReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddDeltaTemperatureCommandHandler(IDeltaTemperatureRepository deltaTemperatureRepository, IReadingModuleReadOnlyRepository readingModuleReadOnlyRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _deltaTemperatureRepository = deltaTemperatureRepository;
        _readingModuleReadOnlyRepository = readingModuleReadOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DeltaTemperatureDto>> Handle(AddDeltaTemperatureCommand request, CancellationToken cancellationToken)
    {
        var readingModules = await _readingModuleReadOnlyRepository.GetAllAsync(cancellationToken);

        if (readingModules == null)
        {
            throw new ReadingModulesListIsNullException();
        }

        var deltaTemperatures = new List<DeltaTemperature>();
        foreach (var readingModule in readingModules)
        {
            var deltaTemperature = await _deltaTemperatureRepository.Add(readingModule.Id);
            await _unitOfWork.SaveChangesAsync();

            deltaTemperatures.Add(deltaTemperature);
        }

        var deltaTemperaturesDto = _mapper.Map<IEnumerable<DeltaTemperatureDto>>(deltaTemperatures);

        return deltaTemperaturesDto;
    }
}

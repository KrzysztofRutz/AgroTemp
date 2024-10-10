using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Temperatures.AddTemperature;

public class AddTemperatureCommandHandler : ICommandHandler<AddTemperatureCommand, IEnumerable<TemperatureDto>>
{
	private readonly ITemperatureRepository _temperatureRepository;
	private readonly IReadingModuleReadOnlyRepository _readingModuleReadOnlyRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public AddTemperatureCommandHandler(ITemperatureRepository temperatureRepository, IReadingModuleReadOnlyRepository readingModuleReadOnlyRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
		_temperatureRepository = temperatureRepository;
		_readingModuleReadOnlyRepository = readingModuleReadOnlyRepository;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<IEnumerable<TemperatureDto>> Handle(AddTemperatureCommand request, CancellationToken cancellationToken)
	{
		var readingModules = await _readingModuleReadOnlyRepository.GetAllAsync(cancellationToken);

		if (readingModules == null)
		{
			throw new ReadingModulesListIsNullException();
		}

		var temperatures = new List<Temperature>();
		foreach (var readingModule in readingModules)
		{
			var temperature = await _temperatureRepository.Add(readingModule);
			await _unitOfWork.SaveChangesAsync();

			temperatures.Add(temperature);
		}

		var temperaturesDto = _mapper.Map<IEnumerable<TemperatureDto>>(temperatures);

		return temperaturesDto;
	}
}

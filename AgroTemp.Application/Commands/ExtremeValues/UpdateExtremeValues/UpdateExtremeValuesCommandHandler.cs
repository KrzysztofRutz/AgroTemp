using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.ExtremeValues.UpdateExtremeValues;

public class UpdateExtremeValuesCommandHandler : ICommandHandler<UpdateExtremeValuesCommand, ExtremeValuesDto>
{
    private readonly IExtremeValuesRepository _extremeValuesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateExtremeValuesCommandHandler(IExtremeValuesRepository extremeValuesRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _extremeValuesRepository = extremeValuesRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ExtremeValuesDto> Handle(UpdateExtremeValuesCommand request, CancellationToken cancellationToken)
    {
        var extremeValues = await _extremeValuesRepository.GetBySiloIdAsync(request.SiloId);

        if (extremeValues == null)
        {
            throw new SiloNotFoundException(request.SiloId);
        }

        extremeValues.MaxTemperature = request.MaxTemperature;
        extremeValues.MinTemperature = request.MinTemperature;  
        extremeValues.MaxDeltaTemperature = request.MaxDeltaTemperature;

        _extremeValuesRepository.Update(extremeValues);
        await _unitOfWork.SaveChangesAsync();

        var extremeValuesDto = _mapper.Map<ExtremeValuesDto>(extremeValues);

        return extremeValuesDto;
    }
}

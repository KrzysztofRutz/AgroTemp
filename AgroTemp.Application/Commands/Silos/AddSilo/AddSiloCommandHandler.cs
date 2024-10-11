using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Silo;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Silos.AddSilo;

public class AddSiloCommandHandler : ICommandHandler<AddSiloCommand, SiloDto>
{
    private readonly ISiloRepository _siloRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddSiloCommandHandler(ISiloRepository siloRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _siloRepository = siloRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<SiloDto> Handle(AddSiloCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _siloRepository.IsAlreadyExistAsync(request.Name, cancellationToken);

        if (isAlreadyExist)
        {
            throw new SiloIsAlreadyExistException(request.Name);
        }

        var silo = new Silo
        {
            Name = request.Name,
            Size = request.Size,
            PositionX = request.PositionX,
            PositionY = request.PositionY,
            OrderSensors = (OrderSensors)Enum.Parse(typeof(OrderSensors), request.OrderSensors),
        };

        _siloRepository.Add(silo);
        await _unitOfWork.SaveChangesAsync();

        var siloDto = _mapper.Map<SiloDto>(silo);

        return siloDto;
    }
}

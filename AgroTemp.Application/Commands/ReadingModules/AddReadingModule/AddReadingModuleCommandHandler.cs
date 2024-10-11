using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Exceptions;
using AutoMapper;
using System.IO.Ports;

namespace AgroTemp.Application.Commands.ReadingModules.AddReadingModule;

public class AddReadingModuleCommandHandler : ICommandHandler<AddReadingModuleCommand, ReadingModuleDto>
{
    private readonly IReadingModuleRepository _readingModuleRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddReadingModuleCommandHandler(IReadingModuleRepository readingModuleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _readingModuleRepository = readingModuleRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReadingModuleDto> Handle(AddReadingModuleCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _readingModuleRepository.IsAlreadyExistAsync(request.Name, cancellationToken);

        if (isAlreadyExist)
        {
            throw new ReadingModuleIsAlreadyExistException(request.Name);
        }

        var readingModule = new ReadingModule
        {
            Name = request.Name,
            CommunicationType = (CommunicationType)Enum.Parse(typeof(CommunicationType), request.CommunicationType),
            Port_or_AddressIP = request.Port_or_AddressIP,
            ModuleID = request.ModuleID,
            Baudrate = request.Baudrate,
            BitsOfSign = request.BitsOfSign,
            Parity = (Parity)Enum.Parse(typeof(Parity), request.Parity),
            StopBit = (StopBits)Enum.Parse(typeof(StopBits), request.StopBit),
            ModuleType = (ModuleType)Enum.Parse(typeof(ModuleType), request.ModuleType),
        };

        _readingModuleRepository.Add(readingModule);
        await _unitOfWork.SaveChangesAsync();

        var readingModuleDto = _mapper.Map<ReadingModuleDto>(readingModule);

        return readingModuleDto;
    }
}

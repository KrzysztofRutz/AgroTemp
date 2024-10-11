using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Domain.Exceptions;
using System.IO.Ports;

namespace AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;

public class UpdateReadingModuleCommandHandler : ICommandHandler<UpdateReadingModuleCommand>
{
    private readonly IReadingModuleRepository _readingModuleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReadingModuleCommandHandler(IReadingModuleRepository readingModuleRepository, IUnitOfWork unitOfWork)
    {
        _readingModuleRepository = readingModuleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReadingModuleCommand request, CancellationToken cancellationToken)
    {
        var readingModule = await _readingModuleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (readingModule == null)
        {
            throw new ReadingModuleNotFoundException(request.Id);
        }

        readingModule.Name = request.Name;
        readingModule.CommunicationType = (CommunicationType)Enum.Parse(typeof(CommunicationType), request.CommunicationType);
        readingModule.Port_or_AddressIP = request.Port_or_AddressIP;
        readingModule.ModuleID = request.ModuleID;
        readingModule.Baudrate = request.Baudrate;
        readingModule.BitsOfSign = request.BitsOfSign;
		readingModule.Parity = (Parity)Enum.Parse(typeof(Parity), request.Parity);
		readingModule.StopBit = (StopBits)Enum.Parse(typeof(StopBits), request.StopBit);
        readingModule.ModuleType = (ModuleType)Enum.Parse(typeof(ModuleType), request.ModuleType);

        _readingModuleRepository.Update(readingModule);
        await _unitOfWork.SaveChangesAsync();
    }
}

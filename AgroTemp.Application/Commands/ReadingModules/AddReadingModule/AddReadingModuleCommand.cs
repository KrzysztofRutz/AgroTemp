using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Enums.ReadingModule;
using System.IO.Ports;


namespace AgroTemp.Application.Commands.ReadingModules.AddReadingModule;

public class AddReadingModuleCommand : ICommand<ReadingModuleDto>
{
	public string Name { get; set; }
	public string CommunicationType { get; set; }
	public string Port_or_AddressIP { get; set; }
	public int ModuleID { get; set; }
	public Baudrate Baudrate { get; set; }
	public int BitsOfSign { get; set; }
	public string Parity { get; set; }
	public string StopBit { get; set; }
	public string ModuleType { get; set; }
}

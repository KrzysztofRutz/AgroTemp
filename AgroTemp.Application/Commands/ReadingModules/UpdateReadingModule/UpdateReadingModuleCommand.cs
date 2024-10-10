using AgroTemp.Application.Configuration.Commands;
using System.IO.Ports;

namespace AgroTemp.Application.Commands.ReadingModules.UpdateReadingModule;

public class UpdateReadingModuleCommand : ICommand
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string CommunicationType { get; set; }
	public string Port_or_AddressIP { get; set; }
	public int ModuleID { get; set; }
	public int Baudrate { get; set; }
	public int BitsOfSign { get; set; }
	public Parity Parity { get; set; }
	public int StopBit { get; set; }
	public string ModuleType { get; set; }
}

using AgroTemp.Domain.Enums.ReadingModule;
using System.IO.Ports;

namespace AgroTemp.Domain.Entities;

public class ReadingModule : Entity
{
    public string Name { get; set; }
    public CommunicationType CommunicationType { get; set; }
    public string Port_or_AddressIP { get; set; }
    public int ModuleID { get; set; }
    public Baudrate Baudrate { get; set; }
    public int BitsOfSign { get; set; }
	public Parity Parity { get; set; }
	public StopBits StopBit { get; set; }
	public ModuleType ModuleType { get; set; }
    public ICollection<Probe> Probes { get; set; }
    public ICollection<Temperature> Temperatures { get; set; }
    public ICollection<DeltaTemperature> DeltaTemperatures { get; set; }
}

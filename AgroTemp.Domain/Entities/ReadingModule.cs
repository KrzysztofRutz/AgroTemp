namespace AgroTemp.Domain.Entities;

public class ReadingModule : Entity
{
    public string Name { get; set; }
    public string CommunicationType { get; set; }
    public string Port_or_AddressIP { get; set; }
    public int ModuleID { get; set; }
    public int Baudrate { get; set; }
    public int BitsOfSign { get; set; }
    public int StopBit { get; set; }
    public string ModuleType { get; set; }
    public ICollection<Probe> Probes { get; set; }
}

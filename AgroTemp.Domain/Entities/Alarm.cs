using AgroTemp.Domain.Enums.Alarm;

namespace AgroTemp.Domain.Entities;

public class Alarm : Entity
{
    public Description Description { get; set; }
    public string ObjectName { get; set; }
}

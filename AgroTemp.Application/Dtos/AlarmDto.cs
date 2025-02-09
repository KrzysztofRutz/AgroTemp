namespace AgroTemp.Application.Dtos;

public class AlarmDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ObjectName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

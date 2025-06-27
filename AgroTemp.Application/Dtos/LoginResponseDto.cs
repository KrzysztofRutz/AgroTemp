namespace AgroTemp.Application.Dtos;

public class LoginResponseDto
{
    public string Token { get; set; }
    public long TokenExpired { get; set; }
}

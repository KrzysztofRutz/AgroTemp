namespace AgroTemp.WebApp.Model.Authentication;

public class LoginResponse
{
    public string Token { get; set; }
    public long TokenExpired { get; set; }
}

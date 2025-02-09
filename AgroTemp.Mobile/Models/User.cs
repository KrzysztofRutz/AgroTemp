namespace AgroTemp.Mobile.Models;

public class User : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string TypeOfUser { get; set; }
}

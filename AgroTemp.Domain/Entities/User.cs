using AgroTemp.Domain.Enums.User;

namespace AgroTemp.Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login {  get; set; }
    public string Password { get; set; }
    public TypeOfUser TypeOfUser { get; set; }
}

using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Users.UpdateUserParameters;

public class UpdateUserParametersCommand : ICommand
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string TypeOfUser { get; set; }
}

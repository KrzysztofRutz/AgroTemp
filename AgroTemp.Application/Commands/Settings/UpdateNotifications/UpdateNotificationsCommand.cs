using AgroTemp.Application.Configuration.Commands;

namespace AgroTemp.Application.Commands.Settings.UpdateNotifications;

public class UpdateNotificationsCommand : ICommand
{
    public bool IsSMSEnabled { get; set; }
    public bool IsEmailEnabled { get; set; }
}

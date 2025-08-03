using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Authentication.StateContainers;

public class UserState
{
    public User User { get; private set; } = new User();

    public event Action OnChange;

    public void SetUser(User user)
    {
        User = user;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() 
        => OnChange?.Invoke();
}

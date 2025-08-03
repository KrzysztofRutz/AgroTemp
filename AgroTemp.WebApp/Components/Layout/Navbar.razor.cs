using AgroTemp.WebApp.Authentication.StateContainers;
using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace AgroTemp.WebApp.Components.Layout;

public partial class Navbar
{
    [Parameter]
    public string PageTitle { get; set; }
    [Parameter]
    public EventCallback<string> PageTitleChanged { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; }
    [Inject]
    public IAlarmService AlarmService { get; set; }
    [Inject]
    public UserState UserState { get; set; }

    public string _pageTitle = "Dashboard";
    private int _activeAlarmsCount;

    private IEnumerable<Alarm> _activeAlarms = new List<Alarm>();
    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthStateProvider.GetAuthenticationStateAsync();
        var userAuthorize = authState.User;
        
        if (userAuthorize.Identity.IsAuthenticated)
        {
            var user = new User
            {
                Id = int.Parse(userAuthorize.FindFirst(c => c.Type == "UserId")?.Value),
                FirstName = userAuthorize.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value,
                LastName = userAuthorize.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value,
                TypeOfUser = userAuthorize.FindFirst(c => c.Type == ClaimTypes.Role)?.Value
            };

            UserState.SetUser(user); 
            UserState.OnChange += StateHasChanged;
        }     

        _activeAlarms = await AlarmService.GetActiveAlarmsAsync();
        _activeAlarmsCount = _activeAlarms.Count();
    }

    private async Task SeeAllActiveAlarms_Click()
        => await PageTitleChanged.InvokeAsync("Alarmy aktywne");

    private async Task MyProfileSettings_Click()
        => await PageTitleChanged.InvokeAsync("Mój Profil");

    public void Dispose()
        => UserState.OnChange -= StateHasChanged;
}

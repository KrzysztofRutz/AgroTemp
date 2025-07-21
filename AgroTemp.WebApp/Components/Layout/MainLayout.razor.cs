using AgroTemp.WebApp.Authentication;
using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace AgroTemp.WebApp.Components.Layout;

public partial class MainLayout
{
    [Inject]
    NavigationManager Navigation { get; set; }
    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; }
    [Inject]
    public IAlarmService AlarmService { get; set; }
    [Inject]
    public IJSRuntime JS { get; set; }

    public string _pageTitle = "Dashboard";
    private string? _firstName;
    private string? _fullName;
    private int _userId;
    private string? _role;
    private int _activeAlarmsCount;
    private IEnumerable<Alarm> _activeAlarms = new List<Alarm>();

    protected override async Task OnInitializedAsync()
    {
        var authState = await ((CustomAuthStateProvider)AuthStateProvider).GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            _firstName = user.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value;
            _userId = int.Parse(user.FindFirst(c => c.Type == "UserId")?.Value);
            _fullName = $"{_firstName} {user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value}";
            _role = user.FindFirst(c => c.Type == ClaimTypes.Role)?.Value;          
        }

        _activeAlarms = await AlarmService.GetActiveAlarmsAsync();
        _activeAlarmsCount = _activeAlarms.Count();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeAsync<IJSObjectReference>("import", "./assets/js/kaiadmin.min.js");
            await JS.InvokeAsync<IJSObjectReference>("import", "./assets/js/plugin/bootstrap-notify/bootstrap-notify.min.js");
        }
            
    }

    private void SeeAllActiveAlarms_Click()
        => _pageTitle = "Alarmy aktywne";

    private void MyProfileSettings_Click()
    {
        _pageTitle = "Mój Profil";
    }
}

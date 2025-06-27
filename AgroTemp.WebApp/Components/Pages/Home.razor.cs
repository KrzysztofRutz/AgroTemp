using AgroTemp.WebApp.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AgroTemp.WebApp.Components.Pages;

public partial class Home
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; }
    [CascadingParameter]
    public HttpContext HttpContext { get; set; }

    protected async override Task OnInitializedAsync()
    {
        var authState = await ((CustomAuthStateProvider)AuthStateProvider).GetAuthenticationStateAsync();

        if (authState.User.Identity.IsAuthenticated)
        {
            Navigation.NavigateTo("/Dashboard", true);
        }
        else
        {
            Navigation.NavigateTo("/login", true);
        }
    }
}

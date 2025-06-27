using AgroTemp.WebApp.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AgroTemp.WebApp.Components.Pages.Authentication;

public partial class Logout
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; }
    [CascadingParameter]
    public HttpContext HttpContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ((CustomAuthStateProvider)AuthStateProvider).MarkUserAsLoggedOut();

        Navigation.NavigateTo("/login");
    }
}

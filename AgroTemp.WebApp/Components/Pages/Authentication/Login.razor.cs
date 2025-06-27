using AgroTemp.WebApp.Authentication;
using AgroTemp.WebApp.Model.Authentication;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AgroTemp.WebApp.Components.Pages.Authentication;

public partial class Login
{
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject]
    public HttpClient HttpClient { get; set; }
    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; }
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }
    [SupplyParameterFromForm]   
    public LoginViewModel Model { get; set; } = new();
    private string? errorMessage;

    
    private async Task AuthenticateAsync()
    {
        var response = await HttpClient.PostAsJsonAsync("api/Authentication", Model);

        var result = response.Content.ReadFromJsonAsync<LoginResponse>().Result;

        if (!response.IsSuccessStatusCode || result.Token == null)
        {
            errorMessage = "Niepoprawna nazwa użytkownika lub hasło.";
            return;
        }

        await ((CustomAuthStateProvider)AuthStateProvider).MarkUserAsAuthenticated(result.Token);

        Navigation.NavigateTo("/");
    }
}

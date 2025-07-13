using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Pages;

public partial class UserProfile
{
    [Inject]
    public IUserService UserService { get; set; }

    [Parameter]
    public int UserId { get; set; }
    private ChartsViewModel Model { get; set; } = new();
    private User _user = new();

    protected override async Task OnInitializedAsync()
    {
        _user = await UserService.GetByIdAsync(UserId);
    }

    private async Task SaveChangesAsync(Microsoft.AspNetCore.Components.Forms.EditContext args)
    {
        throw new NotImplementedException();
    }
}

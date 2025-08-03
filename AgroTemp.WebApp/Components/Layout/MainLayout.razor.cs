using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AgroTemp.WebApp.Components.Layout;

public partial class MainLayout
{
    [Inject]
    public IJSRuntime JS { get; set; }

    public string _pageTitle = "Dashboard";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeAsync<IJSObjectReference>("import", "./assets/js/kaiadmin.min.js");
    }
}

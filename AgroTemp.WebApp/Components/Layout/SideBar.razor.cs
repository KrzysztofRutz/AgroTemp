using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Layout;

public partial class Sidebar
{
    [Parameter]
    public string PageTitle { get; set; }
    [Parameter]
    public EventCallback<string> PageTitleChanged { get; set; }

    private async Task ActiveAlarms_Click()
        => await PageTitleChanged.InvokeAsync("Alarmy aktywne");

    private async Task Dashboard_Click()
        => await PageTitleChanged.InvokeAsync("Dashboard");

    private async Task HistoryAlarms_Click()
        => await PageTitleChanged.InvokeAsync("Historia alarmów");

    private async Task Settings_Click()
        => await PageTitleChanged.InvokeAsync("Ustawienia");
}

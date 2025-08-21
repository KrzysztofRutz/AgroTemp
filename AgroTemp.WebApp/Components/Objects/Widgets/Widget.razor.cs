using Microsoft.AspNetCore.Components;

namespace AgroTemp.WebApp.Components.Objects.Widgets;

public partial class Widget
{
    [Parameter]
    public string Title { get; set; } = string.Empty;
    [Parameter]
    public string Value { get; set; } = string.Empty;
    [Parameter]
    public string Icon { get; set; } = string.Empty;
    [Parameter]
    public string IconStyle { get; set; } = "icon-primary";
}

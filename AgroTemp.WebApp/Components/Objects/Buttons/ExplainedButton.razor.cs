using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WebApp.Components.Objects.Buttons;

public partial class ExplainedButton
{
    [Parameter]
    public EventCallback<bool> OnExplainedChanged { get; set; }

    private bool _isExplained = false;
    private string _explainedButtonIcon = "fas fa-arrow-down";
    private string _explainedButtonText = "Rozwiń";
    private async Task ChangeCardBodyStateAsync(MouseEventArgs args)
    {
        if (_isExplained)
        {
            _isExplained = false;
            _explainedButtonIcon = "fas fa-arrow-down";
            _explainedButtonText = "Rozwiń";
        }
        else
        {
            _isExplained = true;
            _explainedButtonIcon = "fas fa-arrow-up";
            _explainedButtonText = "Zwiń";
        }

        await Task.Delay(1);
        await OnExplainedChanged.InvokeAsync(_isExplained);
    }
}

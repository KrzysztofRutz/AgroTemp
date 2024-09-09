using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using AgroTemp.WWW.Data;
using BlazorBootstrap;

namespace AgroTemp.WWW.Pages.Service.Silos;

public partial class EditModalSilo
{
    private Silo silo = new Silo();
    private List<ToastMessage> toastMessages = new List<ToastMessage>();
    private HttpResponseMessage Message { get; set; } = new HttpResponseMessage();

    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }

    private async Task Submit()
    {
        Message = await siloService.UpdateAsync(silo);

        if (Message.IsSuccessStatusCode)
        {
			await OnClickCallback.InvokeAsync();
		}
        else
        {
            toastMessages.Add(new ToastMessage
            {
                Type = ToastType.Danger,
                Title = "Błąd",
                HelpText = $"AgroTempBot {DateTime.Now}",
                Message = $"Nie udało się edytować zbiornika {silo.Name}. \n Powód: {Message.ReasonPhrase}"
            });
        }       
    }

    protected override async Task OnInitializedAsync()
    {
        silo = await siloService.GetByIdAsync(Id);
    }
}

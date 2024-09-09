using AgroTemp.WWW.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WWW.Pages.Service.Silos;

public partial class DeleteModalSilo
{
    [Parameter]
    public Silo Silo { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }

    private async Task DeleteAccepted()
    {
        await siloService.RemoveAsync(Silo);

		await OnClickCallback.InvokeAsync();
	}

	private async Task DeleteCanceled()
	{
		await OnClickCallback.InvokeAsync();
	}

}

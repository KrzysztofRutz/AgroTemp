using AgroTemp.WWW.Data;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WWW.Pages.Service.Silos
{
    public partial class Silos
    {
        public bool ShowEdit { get; set; }
        public IEnumerable<Silo> _Silos { get; set; }

        public Silo Silo { get; set; } = new Silo();
        private List<ToastMessage> toastMessages = new List<ToastMessage>();
        public HttpResponseMessage Message { get; set; } = new HttpResponseMessage();
        public Modal modalEdit = default!;
        public Modal modalDelete = default!;
        public string orderSensorsText;

        private async Task GoEditModal(Silo silo)
        {
            var parameters = new Dictionary<string, object>
            {
                { nameof(silo.Id), silo.Id },
                { "OnClickCallback", EventCallback.Factory.Create<MouseEventArgs>(this, () => RefreshDataEdit(silo.Name)) }
            };

            await modalEdit.ShowAsync<EditModalSilo>(title: $"Silos {silo.Name}", parameters: parameters);
        }

        private async Task GoDeleteModal(Silo silo)
        {
            var parameters = new Dictionary<string, object>
            {
                { nameof(silo), silo },
                { "OnClickCallback", EventCallback.Factory.Create<MouseEventArgs>(this, () => RefreshDataDelete(silo) ) }
            };

            await modalDelete.ShowAsync<DeleteModalSilo>(title: $"Silos {silo.Name}", parameters: parameters);
        }

		private async Task Submit(EditContext editContext)
        {
            Message = await siloService.AddAsync(Silo);

            _Silos = await siloService.GetAllAsync();
        }

        protected override async Task OnInitializedAsync()
            => _Silos = await siloService.GetAllAsync();

		private async Task RefreshDataEdit(string name)
		{
            toastMessages.Add(new ToastMessage
            {
                Type = ToastType.Success,
                Title = "Powodzenie",
                HelpText = $"AgroTempBot {DateTime.Now}",
                Message = $"Edycja zbiornika {name} przebiegła pomyślnie."
            });

            _Silos = await siloService.GetAllAsync();
			await modalEdit.HideAsync();
		}

		private async Task RefreshDataDelete(Silo silo)
		{
            try
            {
                await siloService.GetByIdAsync(silo.Id);
            }
            catch
            {
				toastMessages.Add(new ToastMessage
				{
					Type = ToastType.Success,
					Title = "Powodzenie",
					HelpText = $"AgroTempBot {DateTime.Now}",
					Message = $"Pomyślnie usunięto zbiornik {silo.Name}."
				});
			}

			_Silos = await siloService.GetAllAsync();
			await modalDelete.HideAsync();
		}

        private async Task OnDelete(Silo silo)
        {
            Message = await siloService.RemoveAsync(silo);

            _Silos = await siloService.GetAllAsync();
        }
    }
}

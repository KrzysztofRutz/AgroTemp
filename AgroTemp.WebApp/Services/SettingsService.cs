using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;

namespace AgroTemp.WebApp.Services;

public class SettingsService : ISettingsService
{
    private readonly HttpClient _httpClient;
    private readonly INotificationService _notificationService;

    public SettingsService(HttpClient httpClient, INotificationService notificationService)
    {
        _httpClient = httpClient;
        _notificationService = notificationService;
    }

    public async Task<Settings> GetAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<Settings>("api/settings");

    public async Task UpdateFrequencyOfReadingAsync(int frequencyOfReading)
    {
        var result = await _httpClient.PatchAsJsonAsync("api/settings/frequencyOfReading", new { frequencyOfReading });

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync("Wystąpił problem podczas aktualizacji częstotliwości odczytu.");
            return;
        }

        await _notificationService.ShowSuccessAsync($"Poprawnie zaktualizowano częstotliwość odczytu na co {frequencyOfReading}h.");
    }

    public async Task UpdateHourOfReadingAsync(int hourOfReading)
    {
        var result = await _httpClient.PatchAsJsonAsync("api/settings/hourOfReading", new { hourOfReading });

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync($"Wystąpił problem podczas aktualizacji godziny odczytu.");
            return;
        }

        await _notificationService.ShowSuccessAsync($"Poprawnie zaktualizowano godzinę odczytu na {hourOfReading}:00.");
    }

    public async Task UpdateLanguageAsync(string language)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateNotificationsAsync(bool isSMSEnabled, bool isEmailEnabled)
    {
        var result = await _httpClient.PatchAsJsonAsync("api/settings/notifications", new { isSMSEnabled, isEmailEnabled });

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync($"Wystąpił problem podczas aktualizacji trybu powiadomień.");
            return;
        }

        await _notificationService.ShowSuccessAsync($"Poprawnie zaktualizowano tryb powiadomień.");
    }
}

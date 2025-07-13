using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;

namespace AgroTemp.WebApp.Services;

public class SettingsService : ISettingsService
{
    private readonly HttpClient _httpClient;

    public SettingsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Settings> GetAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<Settings>("api/settings");

    public void UpdateFrequencyOfReading(int frequencyOfReading)
    {
        throw new NotImplementedException();
    }

    public void UpdateHourOfReading(int hourOfReading)
    {
        throw new NotImplementedException();
    }

    public void UpdateLanguage(string language)
    {
        throw new NotImplementedException();
    }
}

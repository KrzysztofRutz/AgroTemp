using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Newtonsoft.Json;

namespace AgroTemp.Mobile.Services;

public class SettingsService : ISettingsService
{
    private readonly HttpClient _httpClient;

    public SettingsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Settings> GetAsync()
    {
        var result = await _httpClient.GetAsync("api/settings");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var settings = JsonConvert.DeserializeObject<Settings>(content);

        return settings;
    }
}

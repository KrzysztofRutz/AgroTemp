using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Newtonsoft.Json;

namespace AgroTemp.WebApp.Services;

public class ExtremeValuesService : IExtremeValuesService
{
    private readonly HttpClient _httpClient;
    private readonly INotificationService _notificationService;

    public ExtremeValuesService(HttpClient httpClient, INotificationService notificationService)
    {
        _httpClient = httpClient;
        _notificationService = notificationService;
    }

    public async Task<IEnumerable<ExtremeValues>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync("api/extremeValues", cancellationToken);

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync($"Wystąpił problem z odczytem wartości granicznych zbiorników.");
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var extremeValues = JsonConvert.DeserializeObject<IEnumerable<ExtremeValues>>(content);

        return extremeValues;
    }

    public async Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync($"api/extremeValues/silos/{siloId}", cancellationToken);

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync($"Wystąpił problem z odczytem wartości granicznych zbiornika.");
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var extremeValues = JsonConvert.DeserializeObject<ExtremeValues>(content);

        return extremeValues;
    }

    public async Task UpdateAsync(ExtremeValues extremeValues)
    {
        var result = await _httpClient.PutAsJsonAsync("api/extremeValues", extremeValues);

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync("Wystąpił problem z edycją wartości granicznych.");
            return;
        }

        await _notificationService.ShowSuccessAsync("Wartości graniczne zostały zaktualizowane.");
    }
}

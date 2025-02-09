using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Newtonsoft.Json;

namespace AgroTemp.Mobile.Services;

public class ExtremeValuesService : IExtremeValuesService
{
    private readonly HttpClient _httpClient;

    public ExtremeValuesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync($"api/extremeValues/silos/{siloId}");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();
        var extremeValues = JsonConvert.DeserializeObject<ExtremeValues>(content);

        return extremeValues;
    }
}

using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Newtonsoft.Json;

namespace AgroTemp.Mobile.Services;

public class ProbeService : IProbeService
{
    private readonly HttpClient _httpClient;

    public ProbeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProbeWithDetails>> GetWithDeltailsBySiloIdAsync(int siloId)
    {
        var result = await _httpClient.GetAsync($"api/probes/GetWithDetailsBySiloId/{siloId}");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var probes = JsonConvert.DeserializeObject<IEnumerable<ProbeWithDetails>>(content);

        return probes;
    }
}

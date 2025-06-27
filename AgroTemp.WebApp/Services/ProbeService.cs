using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Newtonsoft.Json;

namespace AgroTemp.WebApp.Services;

public class ProbeService : IProbeService
{
    private readonly HttpClient _httpClient;

    public ProbeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Probe>> GetAllAsync()
        => await _httpClient.GetFromJsonAsync<IEnumerable<Probe>>("api/probes");

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

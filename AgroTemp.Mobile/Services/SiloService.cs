using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Newtonsoft.Json;

namespace AgroTemp.WWW.Services;

public class SiloService : ISiloService
{
    private readonly HttpClient _httpClient;

    public SiloService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Silo>> GetAllAsync()
    {
        var result = await _httpClient.GetAsync("api/silos");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var silos = JsonConvert.DeserializeObject<IEnumerable<Silo>>(content);

        return silos;
    }
        

    public async Task<Silo> GetByIdAsync(int id)
    {
        var result = await _httpClient.GetAsync($"api/silos/{id}");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var silo = JsonConvert.DeserializeObject<Silo>(content);

        return silo;
    }
}

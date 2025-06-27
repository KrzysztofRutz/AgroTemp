 using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;

namespace AgroTemp.WebApp.Services;

public class SiloService : ISiloService
{
    private readonly HttpClient _httpClient;

    public SiloService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Silo>> GetAllAsync()
        => await _httpClient.GetFromJsonAsync<IEnumerable<Silo>>("api/silos");

    public async Task<Silo> GetByIdAsync(int id)
        => await _httpClient.GetFromJsonAsync<Silo>($"api/silos/{id}");

    public async Task<HttpResponseMessage> AddAsync(Silo silo)
        => await _httpClient.PostAsJsonAsync("api/silos", silo);

    public async Task<HttpResponseMessage> UpdateAsync(Silo silo)
        => await _httpClient.PutAsJsonAsync("api/silos", silo);

    public async Task<HttpResponseMessage> RemoveAsync(Silo silo)
        => await _httpClient.DeleteAsync($"api/silos/{silo.Id}");
}

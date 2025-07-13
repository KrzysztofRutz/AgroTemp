using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Newtonsoft.Json;
using System.Web;

namespace AgroTemp.WebApp.Services;

public class DeltaTemperatureService : IValueWithTimeStampService<DeltaTemperature>
{
    private readonly HttpClient _httpClient;

    public DeltaTemperatureService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<DeltaTemperature>> GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(int probeId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default)
    {
        var startDatetimeEncode = HttpUtility.UrlEncode(startDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        var endDatetimeEncode = HttpUtility.UrlEncode(endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));

        var result = await _httpClient.GetAsync($"api/deltaTemperatures?probeId={probeId}&startDateTime={startDatetimeEncode}&endDateTime={endDatetimeEncode}");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var deltas = JsonConvert.DeserializeObject<IEnumerable<DeltaTemperature>>(content);

        return deltas;
    }
}

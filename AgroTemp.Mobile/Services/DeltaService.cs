using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Newtonsoft.Json;
using System.Web;

namespace AgroTemp.Mobile.Services;

public class DeltaService : IValueWithTimeStampService<Delta>
{
    private readonly HttpClient _httpClient;

    public DeltaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Delta>> GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(int probeId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default)
    {
        var startDatetimeEncode = HttpUtility.UrlEncode(startDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        var endDatetimeEncode = HttpUtility.UrlEncode(endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));

        var result = await _httpClient.GetAsync($"api/deltaTemperatures?probeId={probeId}&startDateTime={startDatetimeEncode}&endDateTime={endDatetimeEncode}");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var deltas = JsonConvert.DeserializeObject<IEnumerable<Delta>>(content);

        return deltas;
    }
}

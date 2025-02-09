using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Newtonsoft.Json;
using System.Web;

namespace AgroTemp.Mobile.Services;

public class AlarmService : IAlarmService
{
    private readonly HttpClient _httpClient;

    public AlarmService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Alarm>> GetActiveAlarmsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync("api/alarms/active");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var alarms = JsonConvert.DeserializeObject<IEnumerable<Alarm>>(content);

        return alarms;
    }

    public async Task<IEnumerable<Alarm>> GetAlarmsByTimeIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        var startDateEncode = HttpUtility.UrlEncode(startDate.ToString("yyyy-MM-dd HH:mm:ss"));
        var endDateEncode = HttpUtility.UrlEncode(endDate.ToString("yyyy-MM-dd HH:mm:ss"));

        var result = await _httpClient.GetAsync($"api/alarms?startDate={startDateEncode}&endDate={endDateEncode}", cancellationToken);

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();
        var alarms = JsonConvert.DeserializeObject<IEnumerable<Alarm>>(content);

        return alarms;
    }
}

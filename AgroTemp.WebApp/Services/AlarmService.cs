using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Newtonsoft.Json;
using System.Web;

namespace AgroTemp.WebApp.Services;

public class AlarmService : IAlarmService
{
    private readonly HttpClient _httpClient;
    private readonly INotificationService _notificationService;

    public AlarmService(HttpClient httpClient, INotificationService notificationService)
    {
        _httpClient = httpClient;
        _notificationService = notificationService;
    }

    public async Task<IEnumerable<Alarm>> GetActiveAlarmsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync("api/alarms/active");

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync("Wystąpił problem z odczytem aktywnych alarmów.");
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();

        var alarms = JsonConvert.DeserializeObject<IEnumerable<Alarm>>(content);

        return alarms.OrderByDescending(x => x.CreatedAtToDisplay);
    }

    public async Task<IEnumerable<Alarm>> GetAlarmsByTimeIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        var startDateEncode = HttpUtility.UrlEncode(startDate.ToString("yyyy-MM-dd HH:mm:ss"));
        var endDateEncode = HttpUtility.UrlEncode(endDate.ToString("yyyy-MM-dd HH:mm:ss"));

        var result = await _httpClient.GetAsync($"api/alarms?startDate={startDateEncode}&endDate={endDateEncode}", cancellationToken);

        if (!result.IsSuccessStatusCode)
        {
            await _notificationService.ShowErrorAsync("Wystąpił problem z odczytem alarmów w podanym przedziale czasowym.");
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();
        var alarms = JsonConvert.DeserializeObject<IEnumerable<Alarm>>(content);

        return alarms;
    }
}

using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface IAlarmService
{
    Task<IEnumerable<Alarm>> GetActiveAlarmsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Alarm>> GetAlarmsByTimeIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}

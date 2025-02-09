using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface IAlarmService
{
    Task<IEnumerable<Alarm>> GetActiveAlarmsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Alarm>> GetAlarmsByTimeIntervalAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}

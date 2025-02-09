using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IAlarmRepository
{
    Task<Alarm> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Alarm>> GetAlarmsBetweenCreatedAtAndUpdatedAtAsync(DateTime createdAtTime, DateTime updatedAtTime, CancellationToken cancellationToken = default);
    Task<IEnumerable<Alarm>> GetActiveAlarmsAsync(CancellationToken cancellationToken = default);
    void Add(Alarm alarm);
    void Update(Alarm alarm);
}

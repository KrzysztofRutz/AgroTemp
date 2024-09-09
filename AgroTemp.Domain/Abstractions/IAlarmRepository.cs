using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IAlarmRepository
{
    Task<IEnumerable<Alarm>> GetAlarmsByBetweenCreatedAtAndUpdatedAtAsync(DateTime createdAtTime, DateTime updatedAtTime, CancellationToken cancellationToken = default);
    void Add(Alarm alarm);
    void Update(Alarm alarm);
}

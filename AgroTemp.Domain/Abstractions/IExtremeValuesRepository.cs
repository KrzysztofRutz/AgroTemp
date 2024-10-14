using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions;

public interface IExtremeValuesRepository 
{
    Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default);
    void Add(ExtremeValues entity);
    void Update(ExtremeValues entity);
    void Delete(ExtremeValues entity);
}

using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface IReadingModuleReadOnlyRepository
{
    Task<IEnumerable<ReadingModule>> GetAllAsync(CancellationToken cancellationToken = default);
}

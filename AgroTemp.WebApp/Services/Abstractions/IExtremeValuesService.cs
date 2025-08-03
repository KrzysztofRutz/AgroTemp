using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface IExtremeValuesService
{
    Task<IEnumerable<ExtremeValues>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default);
    Task UpdateAsync(ExtremeValues extremeValues);
}

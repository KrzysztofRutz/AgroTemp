using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface IExtremeValuesService
{
    Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default);
}

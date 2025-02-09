using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface IExtremeValuesService
{
    Task<ExtremeValues> GetBySiloIdAsync(int siloId, CancellationToken cancellationToken = default);
}

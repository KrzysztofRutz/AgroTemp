using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface IProbeService 
{
    Task<IEnumerable<ProbeWithDetails>> GetWithDeltailsBySiloIdAsync(int siloId);
}

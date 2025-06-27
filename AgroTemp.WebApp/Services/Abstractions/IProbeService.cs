using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface IProbeService 
{
    Task<IEnumerable<Probe>> GetAllAsync();
    Task<IEnumerable<ProbeWithDetails>> GetWithDeltailsBySiloIdAsync(int siloId);
}

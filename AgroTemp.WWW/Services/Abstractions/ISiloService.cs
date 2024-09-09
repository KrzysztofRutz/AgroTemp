using AgroTemp.WWW.Data;

namespace AgroTemp.WWW.Services.Abstractions;

public interface ISiloService
{
    Task<IEnumerable<Silo>> GetAllAsync();
    Task<Silo> GetByIdAsync(int id);
    Task<HttpResponseMessage> AddAsync(Silo silo);
    Task<HttpResponseMessage> UpdateAsync(Silo silo);
    Task<HttpResponseMessage> RemoveAsync(Silo silo);
}

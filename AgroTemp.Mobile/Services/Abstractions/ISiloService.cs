using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface ISiloService
{
    Task<IEnumerable<Silo>> GetAllAsync();
    Task<Silo> GetByIdAsync(int id);
}

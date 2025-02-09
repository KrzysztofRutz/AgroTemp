using AgroTemp.Mobile.Models;

namespace AgroTemp.Mobile.Services.Abstractions;

public interface ISettingsService
{
    Task<Settings> GetAsync();
}

using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface ISettingsService
{
    Task<Settings> GetAsync(CancellationToken cancellationToken = default);
    void UpdateLanguage(string language);
    void UpdateHourOfReading(int hourOfReading);
    void UpdateFrequencyOfReading(int frequencyOfReading);
}

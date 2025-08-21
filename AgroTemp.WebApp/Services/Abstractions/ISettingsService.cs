using AgroTemp.WebApp.Models;

namespace AgroTemp.WebApp.Services.Abstractions;

public interface ISettingsService
{
    Task<Settings> GetAsync(CancellationToken cancellationToken = default);
    Task UpdateLanguageAsync(string language);
    Task UpdateHourOfReadingAsync(int hourOfReading);
    Task UpdateFrequencyOfReadingAsync(int frequencyOfReading);
    Task UpdateNotificationsAsync(bool isSMSEnabled, bool isEmailEnabled);
}

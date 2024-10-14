using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Settings;

namespace AgroTemp.Domain.Abstractions;

public interface ISettingsRepository
{
    Task<Settings> GetAsync(CancellationToken cancellationToken = default);
    void UpdateLanguage(Language language);
    void UpdateHourOfReading(int hourOfReading);
    void UpdateFrequencyOfReading(FrequencyOfReading frequencyOfReading);
    
}

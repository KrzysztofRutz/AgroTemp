using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Settings;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class SettingsRepository : ISettingsRepository
{
    private readonly AgroTempDbContext _dbContext;

    public SettingsRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Settings> GetAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Settings.FirstOrDefaultAsync(cancellationToken);

    public void UpdateFrequencyOfReading(FrequencyOfReading frequencyOfReading)
        => _dbContext.Settings.First().FrequencyOfReading = frequencyOfReading;

    public void UpdateHourOfReading(int hourOfReading)
        => _dbContext.Settings.First().HourOfReading = hourOfReading;

    public void UpdateLanguage(Language language)
        => _dbContext.Settings.First().Language = language;
}

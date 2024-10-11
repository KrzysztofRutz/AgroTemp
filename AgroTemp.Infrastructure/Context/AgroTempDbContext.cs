using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.Settings;
using AgroTemp.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Context;

internal class AgroTempDbContext : DbContext
{
    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<Probe> Probes { get; set; }
    public DbSet<ReadingModule> ReadingModules { get; set; }
    public DbSet<Silo> Silos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Temperature> Temperatures { get; set; }
    public DbSet<DeltaTemperature> DeltaTemperatures { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public AgroTempDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_polish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new AlarmsConfiguration());
        modelBuilder.ApplyConfiguration(new ProbesConfiguration());
        modelBuilder.ApplyConfiguration(new ReadingModulesConfiguration());
        modelBuilder.ApplyConfiguration(new SilosConfiguration());
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new TemperaturesConfiguration());
        modelBuilder.ApplyConfiguration(new DeltaTemperaturesConfiguration());
        modelBuilder.ApplyConfiguration(new SettingsConfiguration());
        modelBuilder.Entity<Settings>()
            .HasData(new Settings 
            { 
                Id = 1, 
                Language = Language.ENG, 
                HourOfReading = 12, 
                FrequencyOfReading = FrequencyOfReading.Every24hours, 
                EnableSMSNotificationMode = false, 
                EnableEmailNotificationMode = false, 
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now
            });
    }
}

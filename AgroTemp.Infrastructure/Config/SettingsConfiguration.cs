using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class SettingsConfiguration : BaseEntityConfiguration<Settings>
{
    public override void Configure(EntityTypeBuilder<Settings> builder)
    {
        builder.ToTable("Settings");

        builder.Property(x => x.Language)
            .HasConversion<string>();

        builder.Property(x => x.FrequencyOfReading)
            .HasConversion<int>();

        base.Configure(builder);
    }
}

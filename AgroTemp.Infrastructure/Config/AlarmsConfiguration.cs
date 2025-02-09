using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class AlarmsConfiguration : BaseEntityConfiguration<Alarm>
{
    public override void Configure(EntityTypeBuilder<Alarm> builder)
    {
        builder.ToTable("Alarms");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.ObjectName)
            .IsRequired();

        base.Configure(builder);
    }
}

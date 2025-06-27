using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class ProbesConfiguration : BaseEntityConfiguration<Probe>
{
    public override void Configure(EntityTypeBuilder<Probe> builder)
    {
        builder.ToTable("Probes");

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.SensorsCount)
            .IsRequired();

        builder.Property(x => x.NrFirstSensor)
            .IsRequired();

        builder.Property(x => x.NrOfCircle)
            .IsRequired()
            .HasConversion<int>(); 

        builder.HasOne(x => x.Silo)
            .WithMany(x => x.Probes)
            .HasForeignKey(x => x.SiloId);

        builder.HasOne(x => x.ReadingModule)
            .WithMany(x => x.Probes)
            .HasForeignKey(x => x.ReadingModuleId);

        base.Configure(builder);
    }
}

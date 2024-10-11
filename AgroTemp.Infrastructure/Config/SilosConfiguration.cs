using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class SilosConfiguration : BaseEntityConfiguration<Silo>
{
    public override void Configure(EntityTypeBuilder<Silo> builder)
    {
        builder.ToTable("Silos");

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.Size)
            .IsRequired();

        builder.Property(x => x.PositionX)
            .IsRequired();

        builder.Property(x => x.PositionY)
            .IsRequired();

        builder.Property(x => x.OrderSensors)
            .IsRequired()
            .HasConversion<string>();

        builder.HasMany(x => x.Probes)
            .WithOne(x => x.Silo)
            .HasForeignKey(x => x.SiloId);

        base.Configure(builder);
    }
}

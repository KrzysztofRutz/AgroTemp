using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class ReadingModulesConfiguration : BaseEntityConfiguration<ReadingModule>
{
    public override void Configure(EntityTypeBuilder<ReadingModule> builder)
    {
        builder.ToTable("ReadingModules");

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.CommunicationType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.Port_or_AddressIP)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.ModuleID)
            .IsRequired();

        builder.Property(x => x.Baudrate)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.BitsOfSign)
            .IsRequired();

		builder.Property(x => x.Parity)
			.IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.StopBit)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.ModuleType)
            .IsRequired()
            .HasConversion<string>();

        builder.HasMany(x => x.Probes)
            .WithOne(x => x.ReadingModule)
            .HasForeignKey(x => x.ReadingModuleId);

        builder.HasMany(x => x.Temperatures)
            .WithOne(x => x.ReadingModule)
            .HasForeignKey(x => x.ReadingModuleId);

        builder.HasMany(x => x.DeltaTemperatures)
            .WithOne(x => x.ReadingModule)
            .HasForeignKey(x => x.ReadingModuleId);

        base.Configure(builder);
    }
}

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
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(x => x.Port_or_AddressIP)
            .HasMaxLength(15)
            .IsRequired();

        builder.HasIndex(x => x.ModuleID)
            .IsUnique();

        builder.Property(x => x.ModuleID)
            .IsRequired();

        builder.Property(x => x.Baudrate)
            .IsRequired();

        builder.Property(x => x.BitsOfSign)
            .IsRequired();

        builder.Property(x => x.StopBit)
            .IsRequired();

        builder.Property(x => x.ModuleType)
            .IsRequired();

        builder.HasMany(x => x.Probes)
            .WithOne(x => x.ReadingModule)
            .HasForeignKey(x => x.ReadingModuleId);

        base.Configure(builder);
    }
}

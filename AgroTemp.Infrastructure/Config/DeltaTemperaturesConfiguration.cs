using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class DeltaTemperaturesConfiguration : BaseEntityConfiguration<DeltaTemperature>
{
	public override void Configure(EntityTypeBuilder<DeltaTemperature> builder)
    {
        builder.ToTable("DeltaTemperatures");

        builder.HasOne(x => x.ReadingModule)
            .WithMany(x => x.DeltaTemperatures)
            .HasForeignKey(x => x.ReadingModuleId);

        base.Configure(builder);
    }   
}

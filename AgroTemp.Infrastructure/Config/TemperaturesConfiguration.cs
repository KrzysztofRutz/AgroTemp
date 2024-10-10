using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class TemperaturesConfiguration : BaseEntityConfiguration<Temperature>
{
	public override void Configure(EntityTypeBuilder<Temperature> builder)
	{
		builder.ToTable("Temperatures");

		builder.HasOne(x => x.ReadingModule)
			.WithMany(x => x.Temperatures)
			.HasForeignKey(x => x.ReadingModuleId);

		base.Configure(builder);
	}
}

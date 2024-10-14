using AgroTemp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

internal class ExtremeValuesConfiguration : BaseEntityConfiguration<ExtremeValues>
{
    public override void Configure(EntityTypeBuilder<ExtremeValues> builder)
    {
        base.Configure(builder);
    }
}

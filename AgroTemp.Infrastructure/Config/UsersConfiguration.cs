using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Config.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroTemp.Infrastructure.Config;

public class UsersConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(x => x.FirstName)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.Login)
            .IsUnique();

        builder.Property(x => x.Login)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasMaxLength(50)
            .HasConversion<StringToMD5Converter>()
            .IsRequired();

        builder.Property(x => x.TypeOfUser)
            .IsRequired()
            .HasConversion<string>();

        base.Configure(builder);
    }
}

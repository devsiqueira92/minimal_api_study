using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Infrastructure.Context.EntitiesConfiguration;

public class UserInfoEntityTypeConfiguration : IEntityTypeConfiguration<UserInfoEntity>
{
    public void Configure(EntityTypeBuilder<UserInfoEntity> builder)
    {
        builder.ToTable("TB_USER_INFO");

        builder.Property(f => f.Name)
       .HasColumnName("TXT_NAME")
       .IsRequired();


        builder.Property(f => f.BirthDate)
       .HasColumnName("DAT_BIRTHDATE")
       .IsRequired();


        builder.Property(f => f.Gender)
       .HasColumnName("TXT_GENDER")
       .IsRequired();


        builder.Property(f => f.UserEntityId)
       .HasColumnName("COD_USER")
       .IsRequired();
        builder.HasIndex(ui => ui.UserEntityId).IsUnique();

    }
}

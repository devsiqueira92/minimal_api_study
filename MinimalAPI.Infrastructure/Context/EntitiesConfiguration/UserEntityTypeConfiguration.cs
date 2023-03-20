using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Infrastructure.Context.EntitiesConfiguration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("TB_USER");

        builder.HasOne(ui => ui.UserInfoEntity)
       .WithOne(u => u.UserEntity)
       .HasForeignKey<UserInfoEntity>(p => p.UserEntityId)
       .OnDelete(DeleteBehavior.NoAction);
    }
}

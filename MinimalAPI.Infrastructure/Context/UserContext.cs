using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Infrastructure.Context.EntitiesConfiguration;

namespace MinimalAPI.Infrastructure.Context;

public class UserContext : IdentityDbContext<UserEntity>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    public DbSet<UserEntity> UsersIdentity { get; set; }
    public DbSet<UserInfoEntity> UsersInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This is already configured on the Startup.cs
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<UserEntity>());
        new UserInfoEntityTypeConfiguration().Configure(modelBuilder.Entity<UserInfoEntity>());
    }
}


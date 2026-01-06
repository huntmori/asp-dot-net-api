using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace asp_dot_net_api.Common;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // MariaDB 인덱스 길이 제한 문제를 피하기 위해 컬럼 길이 제한 설정
        builder.Entity<IdentityUser>(entity => {
            entity.Property(m => m.Email).HasMaxLength(191);
            entity.Property(m => m.NormalizedEmail).HasMaxLength(191);
            entity.Property(m => m.UserName).HasMaxLength(191);
            entity.Property(m => m.NormalizedUserName).HasMaxLength(191);
        });
        builder.Entity<IdentityRole>(entity => {
            entity.Property(m => m.Name).HasMaxLength(191);
            entity.Property(m => m.NormalizedName).HasMaxLength(191);
        });
        builder.Entity<IdentityUserLogin<string>>(entity => {
            entity.Property(m => m.LoginProvider).HasMaxLength(191);
            entity.Property(m => m.ProviderKey).HasMaxLength(191);
        });
        builder.Entity<IdentityUserRole<string>>(entity => {
            entity.Property(m => m.UserId).HasMaxLength(191);
            entity.Property(m => m.RoleId).HasMaxLength(191);
        });
        builder.Entity<IdentityUserToken<string>>(entity => {
            entity.Property(m => m.UserId).HasMaxLength(191);
            entity.Property(m => m.LoginProvider).HasMaxLength(191);
            entity.Property(m => m.Name).HasMaxLength(191);
        });
    }
}
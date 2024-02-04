using Infraestructure.Entity.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Database
{
    public class BaseApiDbContext : DbContext
    {
        public BaseApiDbContext(DbContextOptions<BaseApiDbContext> dbContextOptions) : base(dbContextOptions) { }

        // Security
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<RoleEntity> RoleEntity { get; set; }
        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<RolePermissionEntity> RolePermissionEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<PermissionEntity>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<RolePermissionEntity>()
                .HasIndex(r => new { r.IdPermission, r.IdRole })
                .IsUnique();
        }

    }
}

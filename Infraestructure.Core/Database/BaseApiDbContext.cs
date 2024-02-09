using Infraestructure.Entity.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Database
{
    public class BaseApiDbContext : DbContext
    {
        public BaseApiDbContext(DbContextOptions<BaseApiDbContext> dbContextOptions) : base(dbContextOptions) { }

        // Security
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Role>()
                .HasMany(role => role.RolePermissions)
                .WithOne(rolePermission => rolePermission.Role)
                .HasForeignKey(rolePermission => rolePermission.IdRole);

            modelBuilder.Entity<Permission>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Permission>()
                .HasMany(permission => permission.RolePermissions)
                .WithOne(rolePermission => rolePermission.Permission)
                .HasForeignKey(rolePermission => rolePermission.IdPermission);

            modelBuilder.Entity<RolePermission>()
                .HasIndex(r => new { r.IdPermission, r.IdRole })
                .IsUnique();

        }

    }
}

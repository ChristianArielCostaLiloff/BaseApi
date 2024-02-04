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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().Property(t => t.Id).ValueGeneratedNever();
        }

    }
}

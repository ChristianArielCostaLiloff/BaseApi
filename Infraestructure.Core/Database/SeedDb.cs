using Common.BaseApi;
using Infraestructure.Entity.Models.Security;

namespace Infraestructure.Core.Database
{
    public class SeedDb
    {
        #region Attributes
        private readonly BaseApiDbContext _context;
        #endregion

        #region Builder
        public SeedDb(BaseApiDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task InitializeDataAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckRoleAsync();
            await CheckUserAsync();
        }

        public async Task CheckRoleAsync()
        {
            if (!_context.RoleEntity.Any())
            {
                await _context.AddRangeAsync(new List<RoleEntity>()
                {
                    new RoleEntity()
                    {
                        Id = (int)Enums.RoleId.Admin,
                        Description = "Admin"
                    },
                    new RoleEntity()
                    {
                        Id = (int)Enums.RoleId.Manager,
                        Description = "Manager"
                    },
                    new RoleEntity()
                    {
                        Id = (int)Enums.RoleId.User,
                        Description = "User"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckUserAsync()
        {
            if (!_context.UserEntity.Any())
            {
                await _context.AddRangeAsync(new List<UserEntity>()
                {
                    new UserEntity()
                    {
                        Description = "Admin Name",
                        IdRole = (int)Enums.RoleId.Admin
                    },
                    new UserEntity()
                    {
                        Description = "Manager Name",
                        IdRole = (int)Enums.RoleId.Manager
                    },
                    new UserEntity()
                    {
                        Description = "User Name",
                        IdRole = (int)Enums.RoleId.User
                    },
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}

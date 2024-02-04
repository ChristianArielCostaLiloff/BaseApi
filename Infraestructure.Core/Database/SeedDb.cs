using Common.BaseApi;
using Infraestructure.Entity.Models.Security;
using static Common.BaseApi.Enums;

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
            await CheckPermissionAsync();
            await CheckRolePermissionAsync();
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

        public async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>()
                {
                    new PermissionEntity
                    {
                        Id = (int)PermissionId.UserCreate,
                        Name = "Create users",
                        Description = "Permission to create users."
                    },
                    new PermissionEntity
                    {
                        Id = (int)PermissionId.UserRead,
                        Name = "View users",
                        Description = "Permission to view users."
                    },
                    new PermissionEntity
                    {
                        Id = (int)PermissionId.UserUpdate,
                        Name = "Update users",
                        Description = "Permission to update users."
                    },
                    new PermissionEntity
                    {
                        Id = (int)PermissionId.UserDelete,
                        Name = "Delete users",
                        Description = "Permission to delete users."
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckRolePermissionAsync()
        {
            if (!_context.RolePermissionEntity.Any(x => x.IdRole == (int)Enums.RoleId.Admin))
            {
                List<RolePermissionEntity> rolesPermissionAdmin = _context.PermissionEntity.Select(permission => new RolePermissionEntity
                {
                    IdPermission = permission.Id,
                    IdRole = (int)Enums.RoleId.Admin
                }).ToList();

                _context.RolePermissionEntity.AddRange(rolesPermissionAdmin);

                await _context.SaveChangesAsync();
            }

            if (!_context.RolePermissionEntity.Any(x => x.IdRole == (int)Enums.RoleId.Manager))
            {
                List<RolePermissionEntity> rolesPermissionAdmin = new List<RolePermissionEntity>
                {
                    new RolePermissionEntity
                    {
                        IdPermission = (int)Enums.PermissionId.UserRead,
                        IdRole = (int)(int)Enums.RoleId.Manager
                    }
                };

                _context.RolePermissionEntity.AddRange(rolesPermissionAdmin);

                await _context.SaveChangesAsync();
            }
        }

    }
}

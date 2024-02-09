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
            if (!_context.Roles.Any())
            {
                await _context.AddRangeAsync(new List<Role>()
                {
                    new Role()
                    {
                        Id = (int)Enums.RoleId.Admin,
                        Name = "Admin"
                    },
                    new Role()
                    {
                        Id = (int)Enums.RoleId.Manager,
                        Name = "Manager"
                    },
                    new Role()
                    {
                        Id = (int)Enums.RoleId.User,
                        Name = "User"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckUserAsync()
        {
            if (!_context.Users.Any())
            {
                await _context.AddRangeAsync(new List<User>()
                {
                    new User()
                    {
                        Name = "Admin Name",
                        IdRole = (int)Enums.RoleId.Admin
                    },
                    new User()
                    {
                        Name = "Manager Name",
                        IdRole = (int)Enums.RoleId.Manager
                    },
                    new User()
                    {
                        Name = "User Name",
                        IdRole = (int)Enums.RoleId.User
                    },
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckPermissionAsync()
        {
            if (!_context.Permissions.Any())
            {
                _context.Permissions.AddRange(new List<Permission>()
                {
                    new Permission
                    {
                        Id = (int)PermissionId.UserCreate,
                        Name = "Create users",
                        Description = "Permission to create users."
                    },
                    new Permission
                    {
                        Id = (int)PermissionId.UserRead,
                        Name = "View users",
                        Description = "Permission to view users."
                    },
                    new Permission
                    {
                        Id = (int)PermissionId.UserUpdate,
                        Name = "Update users",
                        Description = "Permission to update users."
                    },
                    new Permission
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
            if (!_context.RolePermissions.Any(x => x.IdRole == (int)Enums.RoleId.Admin))
            {
                List<RolePermission> rolesPermissionAdmin = _context.Permissions.Select(permission => new RolePermission
                {
                    IdPermission = permission.Id,
                    IdRole = (int)Enums.RoleId.Admin
                }).ToList();

                _context.RolePermissions.AddRange(rolesPermissionAdmin);

                await _context.SaveChangesAsync();
            }

            if (!_context.RolePermissions.Any(x => x.IdRole == (int)Enums.RoleId.Manager))
            {
                List<RolePermission> rolesPermissionAdmin = new List<RolePermission>
                {
                    new RolePermission
                    {
                        IdPermission = (int)Enums.PermissionId.UserRead,
                        IdRole = (int)(int)Enums.RoleId.Manager
                    }
                };

                _context.RolePermissions.AddRange(rolesPermissionAdmin);

                await _context.SaveChangesAsync();
            }
        }

    }
}

using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services.Interfaces
{
    public interface IRolePermissionCacheService
    {
        public void LoadCache();
        public List<RolePermission> GetRolePermissionsFromCache();
    }
}

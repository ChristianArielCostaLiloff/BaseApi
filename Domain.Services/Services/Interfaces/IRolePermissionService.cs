namespace Domain.Services.Services.Interfaces
{
    public interface IRolePermissionService
    {
        Task<bool> AddPermissionToRole(int roleId, int permissionId);
        Task<bool> RemovePermissionFromRole(int roleId, int permissionId);
    }
}

using Infraestructure.Core.Repository.Interfaces;
using Infraestructure.Entity.Models.Security;

namespace Infraestructure.Core.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        // Security
        IRepository<User> UserRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<Permission> PermissionRepository { get; }
        IRepository<RolePermission> RolePermissionRepository { get; }

        Task<int> Save();

    }
}

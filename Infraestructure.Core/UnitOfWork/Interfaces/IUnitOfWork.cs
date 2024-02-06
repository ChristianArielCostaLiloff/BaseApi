using Infraestructure.Core.Repository.Interfaces;
using Infraestructure.Entity.Models.Security;

namespace Infraestructure.Core.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        // Security
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<UserEntity> UserRepository { get; }

        Task<int> Save();

    }
}

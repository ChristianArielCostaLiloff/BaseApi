using Infraestructure.Core.Repository.Interfaces;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        // Security
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<UserEntity> UserRepository { get; }
    }
}

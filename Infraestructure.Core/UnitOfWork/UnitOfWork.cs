using Infraestructure.Core.Database;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attributes
        private readonly DbContext _context;
        private bool disposed = false;
        #endregion

        #region Builder
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        private IRepository<Role>? _roleRepository;
        private IRepository<User>? _userRepository;
        private IRepository<RolePermission>? _rolePermissionRepository;
        #endregion

        #region Members
        // Lazy Loading
        public IRepository<Role> RoleRepository => _roleRepository ??= new Repository<Role>(_context);
        public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(_context);
        public IRepository<RolePermission> RolePermissionRepository => _rolePermissionRepository ??= new Repository<RolePermission>(_context);
        #endregion

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        public async Task<int> Save() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

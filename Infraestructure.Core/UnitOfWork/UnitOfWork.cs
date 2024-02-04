using Infraestructure.Core.Database;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attributes
        private readonly BaseApiDbContext _context;
        private bool disposed = false;
        #endregion

        #region Builder
        public UnitOfWork(BaseApiDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        private IRepository<RoleEntity> _roleRepository;
        private IRepository<UserEntity> _userRepository;
        #endregion

        #region Members
        public IRepository<RoleEntity> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new Repository<RoleEntity>(_context);

                return _roleRepository;
            }
        }

        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<UserEntity>(_context);

                return _userRepository;
            }
        }
        #endregion

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        public async Task<int> Save() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing) _context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

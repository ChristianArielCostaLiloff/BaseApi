using Domain.Services.Services.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRolePermissionCacheService _rolePermissionCacheService;
        #endregion

        #region Builder
        public RolePermissionService(IUnitOfWork unitOfWork, IRolePermissionCacheService rolePermissionCacheService)
        {
            _unitOfWork = unitOfWork;
            _rolePermissionCacheService = rolePermissionCacheService;
        }
        #endregion

        #region Public Methods
        public async Task<bool> AddPermissionToRole(int idRole, int idPermission)
        {
            var rolePermission = new RolePermission
            {
                IdRole = idRole,
                IdPermission = idPermission
            };
            _unitOfWork.RolePermissionRepository.Insert(rolePermission);

            bool result = await _unitOfWork.Save() > 0;

            if(result) _rolePermissionCacheService.LoadCache();

            return result;
        }

        public async Task<bool> RemovePermissionFromRole(int idRole, int idPermission)
        {
            var rolePermission = _unitOfWork.RolePermissionRepository
                .FirstOrDefault(rp => rp.IdRole == idRole && rp.IdPermission == idPermission);

            if (rolePermission == null) return false;

            _unitOfWork.RolePermissionRepository.Delete(rolePermission);

            bool result = await _unitOfWork.Save() > 0;

            if (result) _rolePermissionCacheService.LoadCache();

            return result;
        }
        #endregion
    }
}

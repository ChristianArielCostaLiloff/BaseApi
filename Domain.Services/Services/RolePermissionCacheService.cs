using Common.BaseApi.Exceptions;
using Common.BaseApi.Messages;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services.Services
{
    public class RolePermissionCacheService
    {
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;

        public RolePermissionCacheService(IMemoryCache cache, IUnitOfWork unitOfWork)
        {
            _cache = cache;
            _unitOfWork = unitOfWork;
        }

        public void LoadCache()
        {
            List<RolePermission> rolePermissions = _unitOfWork.RolePermissionRepository.GetAll().ToList();

            _cache.Set("RolePermissions", rolePermissions);
        }

        public List<RolePermission> GetRolePermissionsFromCache()
        {
            var rolePermissionsCache = _cache.Get<List<RolePermission>>("RolePermissions");

            if (rolePermissionsCache == null)
                throw new CacheException(StatusCodeMessages.CacheEmpty);

            return rolePermissionsCache;
        }
    }
}

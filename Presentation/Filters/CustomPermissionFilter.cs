using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Common.Messages;
using Domain.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Common.Constants.AuthConstants;

namespace Presentation.Filters
{
    public class CustomPermissionFilter : TypeFilterAttribute
    {
        public CustomPermissionFilter(Enums.PermissionId permission) : base(typeof(CustomPermissionFilterImplement))
        {
            Arguments = new object[] { permission };
        }

        private class CustomPermissionFilterImplement : IActionFilter
        {
            private readonly Enums.PermissionId _permissionId;
            private RolePermissionCacheService _rolePermissionCacheService;

            public CustomPermissionFilterImplement(Enums.PermissionId permission, RolePermissionCacheService rolePermissionCacheService)
            {
                _permissionId = permission;
                _rolePermissionCacheService = rolePermissionCacheService;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                string? token = context.HttpContext.Request.Headers["Authorization"];

                if (string.IsNullOrEmpty(token))
                    throw new UnauthorizedAccessException(AuthMessages.TokenNull);

                string idRole = TokenHelper.GetClaimValue(token, TypeClaims.IdRole);

                var rolePermissions = _rolePermissionCacheService.GetRolePermissionsFromCache();

                bool hasPermission = rolePermissions.Any(rp => rp.IdRole == int.Parse(idRole) && rp.IdPermission == (int)_permissionId);

                if (!hasPermission) 
                    throw new BusinessException(AuthMessages.WithoutPermission);

            }

            public void OnActionExecuted(ActionExecutedContext context)
            {

            }
        }
    }
}

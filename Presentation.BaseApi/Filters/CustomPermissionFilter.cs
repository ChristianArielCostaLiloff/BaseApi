using Common.BaseApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.BaseApi.Filters
{
    public class CustomPermissionFilter : TypeFilterAttribute
    {
        public CustomPermissionFilter(Enums.PermissionId permission) : base(typeof(CustomPermissionFilterImplement))
        {
            Arguments = new object[] { permission };
        }

        private class CustomPermissionFilterImplement : IActionFilter
        {
            private readonly Enums.PermissionId _permission;

            public CustomPermissionFilterImplement(Enums.PermissionId permission)
            {
                _permission = permission;
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {

            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                //string token = context.HttpContext.Request.Headers["Authorization"];
                //string idUser = Utils.GetClaimValue(token, TypeClaims.IdUser);
                //string idRol = Utils.GetClaimValue(token, TypeClaims.IdRol);
                ////bool result = _permissionServices.ValidatePermissionByUser(_permission, Convert.ToInt32(idUser), 1);
                //bool result = _permissionServices.ValidatePermissionByUser(_permission, Convert.ToInt32(idUser), Convert.ToInt32(idRol));
                //if (!result)
                //    throw new BusinessException(GeneralMessages.WithoutPermission);
            }
        }
    }
}

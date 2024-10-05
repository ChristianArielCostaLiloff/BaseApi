using Common.Constants;
using Common.Messages;
using Domain.Services.Dtos.Role;
using Domain.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using Presentation.Filters;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class RoleController : ControllerBase
    {
        #region Attributes
        private readonly IRoleService _roleService;
        #endregion

        #region Builder
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        #endregion

        #region Services
        [HttpGet]
        [Route("GetAll")]
        [CustomPermissionFilter(Enums.PermissionId.RoleRead)]
        public IActionResult GetAll()
        {
            List<RoleDto> roleDtos = _roleService.GetAll();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = roleDtos,
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [CustomPermissionFilter(Enums.PermissionId.RoleRead)]
        public IActionResult GetById(int id)
        {
            RoleDto roleDto = _roleService.GetById(id);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = roleDto,
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("Insert")]
        [CustomPermissionFilter(Enums.PermissionId.RoleCreate)]
        public async Task<IActionResult> Insert(AddRoleDto role)
        {
            bool result = await _roleService.Insert(role);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? CrudMessages.CreateSuccess : CrudMessages.CreateError,
                Result = string.Empty,
            };

            return result ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("Update")]
        [CustomPermissionFilter(Enums.PermissionId.RoleUpdate)]
        public async Task<IActionResult> Update(UpdateRoleDto role)
        {
            bool result = await _roleService.Update(role);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? CrudMessages.UpdateSuccess : CrudMessages.UpdateError,
                Result = string.Empty,
            };

            return result ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [CustomPermissionFilter(Enums.PermissionId.RoleDelete)]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _roleService.Delete(id);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isDeleted,
                Message = isDeleted ? CrudMessages.DeleteSuccess : CrudMessages.DeleteError,
                Result = string.Empty,
            };

            return Ok(response);
        }
        #endregion
    }
}

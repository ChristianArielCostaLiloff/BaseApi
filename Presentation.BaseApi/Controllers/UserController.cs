using Common.BaseApi.Constants;
using Common.BaseApi.Messages;
using Domain.Services.Dtos.User;
using Domain.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.BaseApi.Dtos;
using Presentation.BaseApi.Filters;


namespace Presentation.BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly IUserService _userService;
        #endregion

        #region Builder
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Services
        [HttpGet]
        [Route("GetAll")]
        [CustomPermissionFilter(Enums.PermissionId.UserRead)]
        public IActionResult GetAll()
        {
            List<UserDto> userDtos = _userService.GetAll();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = userDtos,
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [CustomPermissionFilter(Enums.PermissionId.UserRead)]
        public IActionResult GetById(int id)
        {
            UserDto userDto = _userService.GetById(id);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = userDto,
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("Insert")]
        [CustomPermissionFilter(Enums.PermissionId.UserCreate)]
        public async Task<IActionResult> Insert(AddUserDto user)
        {
            bool result = await _userService.Insert(user);
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
        [CustomPermissionFilter(Enums.PermissionId.UserUpdate)]
        public async Task<IActionResult> Update(UpdateUserDto user)
        {
            bool result = await _userService.Update(user);
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
        [CustomPermissionFilter(Enums.PermissionId.UserDelete)]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _userService.Delete(id);

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

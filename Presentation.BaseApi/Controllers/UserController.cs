using Domain.Services.Dtos;
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
        #endregion

    }
}

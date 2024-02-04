using Domain.Services.Dtos;
using Domain.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.BaseApi.Dtos;


namespace Presentation.BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            List<UserDto> userDtos = _userService.GetUsers();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = userDtos,
            };

            return Ok(response);
        }
        #endregion
        
    }
}

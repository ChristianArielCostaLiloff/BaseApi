using Domain.Services.Dtos.User.Login;
using Domain.Services.Services;
using Domain.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.BaseApi.Dtos;
using Presentation.BaseApi.Filters;

namespace Presentation.BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestDto login)
        {
            LoginResponseDto result = _userService.Login(login);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };

            return Ok(response);
        }
    }
}

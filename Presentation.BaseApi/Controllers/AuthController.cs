using Domain.Services.Dtos.User.Login;
using Domain.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.BaseApi.Dtos;
using Presentation.BaseApi.Filters;

namespace Presentation.BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestDto login)
        {
            LoginResponseDto result = _authService.AuthenticateUser(login);
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

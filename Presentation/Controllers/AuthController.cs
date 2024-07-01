using Domain.Services.Dtos.Login;
using Domain.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;
using Presentation.Filters;

namespace Presentation.Controllers
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
        public IActionResult Login(AuthRequestDto login)
        {
            AuthResponseDto result = _authService.AuthenticateUser(login);
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

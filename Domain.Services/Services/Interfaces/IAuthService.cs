using Domain.Services.Dtos.User.Login;
using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services.Interfaces
{
    public interface IAuthService
    {
        public LoginResponseDto AuthenticateUser(LoginRequestDto login);
    }

}

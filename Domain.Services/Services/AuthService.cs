using Common.Exceptions;
using Common.Helpers;
using Common.Messages;
using Domain.Services.Dtos.Login;
using Domain.Services.Services.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Common.Constants.AuthConstants;

namespace Domain.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public LoginResponseDto AuthenticateUser(LoginRequestDto login)
        {
            User? user = _unitOfWork.UserRepository.FirstOrDefault(x => x.UserName == login.UserName);

            if (user == null || !PasswordHelper.VerifyPassword(login.Password, user.Password))
                throw new BusinessException(StatusCodeMessages.Status401Unauthorized);

            LoginResponseDto loginResponse = new LoginResponseDto { Token = GenerateToken(user) };

            return loginResponse;
        }

        private string GenerateToken(User user)
        {
            IConfigurationSection tokenAppSetting = _configuration.GetSection("Tokens");

            string key = tokenAppSetting["Key"] ?? throw new ArgumentNullException("Key is null in appsettings.json");
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(TypeClaims.IdUser, user.Id.ToString()),
                new Claim(TypeClaims.IdRole, user.IdRole.ToString()),
            };

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = signingCredentials,
                Issuer = tokenAppSetting["Issuer"],
                Audience = tokenAppSetting["Audience"]
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
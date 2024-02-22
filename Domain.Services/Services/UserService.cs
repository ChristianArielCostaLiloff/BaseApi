using Common.BaseApi.Exceptions;
using Common.BaseApi.Messages;
using Common.BaseApi.Helpers;
using Domain.Services.Dtos.User;
using Domain.Services.Dtos.User.Login;
using Domain.Services.Services.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Domain.Services.Services
{
    public class UserService : IUserService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        #endregion

        #region Auth
        public LoginResponseDto Login(LoginRequestDto login)
        {
            User? user = _unitOfWork.UserRepository.FirstOrDefault(x => x.UserName == login.UserName);

            if (user == null || !PasswordHelper.VerifyPassword(login.Password, user.Password))
                throw new BusinessException(StatusCodeMessages.Status401Unauthorized);

            LoginResponseDto loginResponse = new LoginResponseDto { Token = GenerateJwtToken(user) };

            return loginResponse;
        }

        private string GenerateJwtToken(User user)
        {
            IConfigurationSection tokenAppSetting = _configuration.GetSection("Tokens");

            string key = tokenAppSetting["Key"] ?? throw new ArgumentNullException("Key is null in appsettings.json");
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim("IdUser", user.Id.ToString()),
                new Claim("IdRole", user.IdRole.ToString()),
                // Add other claims as needed
            };

            // Serialize user permissions to JSON
            List<int> permissions = user.Role.RolePermissions.Select(rp => rp.IdPermission).ToList();
            string permissionsJson = JsonConvert.SerializeObject(permissions);
            claims.Add(new Claim("IdsPermissions", permissionsJson));

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

        #endregion

        #region Public Methods
        public List<UserDto> GetAll()
        {
            IEnumerable<User> userEntityList = _unitOfWork.UserRepository.GetAll();

            List<UserDto> userDtoList = userEntityList.Select(user => new UserDto
            {
                Id = user.Id,
                Description = user.Name
            }).ToList();

            return userDtoList;
        }

        public UserDto GetById(int id)
        {
            User userEntity = GetUserEntity(id);

            UserDto userDto = new UserDto
            {
                Id = userEntity.Id,
                Description = userEntity.Name
            };

            return userDto;
        }

        public async Task<bool> Insert(AddUserDto user)
        {
            User userEntity = new User
            {
                Name = user.Description,
                IdRole = user.IdRole,
            };
            _unitOfWork.UserRepository.Insert(userEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(UpdateUserDto user)
        {
            User userEntity = GetUserEntity(user.Id);

            userEntity.Name = user.Description;
            userEntity.IdRole = user.IdRole;

            _unitOfWork.UserRepository.Update(userEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            User userEntity = GetUserEntity(id);

            _unitOfWork.UserRepository.Delete(userEntity);

            return await _unitOfWork.Save() > 0;
        }
        #endregion

        #region Private Methods
        private User GetUserEntity(int id)
        {
            User? userEntity = _unitOfWork.UserRepository.FirstOrDefault(user => user.Id == id);

            if (userEntity == null)
                throw new BusinessException(CrudMessages.NotFound);

            return userEntity;
        }
        #endregion
    }
}

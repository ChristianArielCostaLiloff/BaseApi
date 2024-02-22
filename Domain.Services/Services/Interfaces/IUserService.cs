using Domain.Services.Dtos.User;
using Domain.Services.Dtos.User.Login;
using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services.Interfaces
{
    public interface IUserService
    {
        #region Auth
        public LoginResponseDto Login(LoginRequestDto login);
        #endregion

        public List<UserDto> GetAll();
        public UserDto GetById(int id);
        public Task<bool> Insert(AddUserDto dto);
        public Task<bool> Update(UpdateUserDto user);
        public Task<bool> Delete(int id);

    }
}

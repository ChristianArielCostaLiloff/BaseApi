using Domain.Services.Dtos.User;

namespace Domain.Services.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserDto> GetAll();
        public UserDto GetById(int id);
        public Task<bool> Insert(AddUserDto dto);
        public Task<bool> Update(UpdateUserDto user);
        public Task<bool> Delete(int id);

    }
}

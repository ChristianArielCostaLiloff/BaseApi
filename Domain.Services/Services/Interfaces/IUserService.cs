using Domain.Services.Dtos;

namespace Domain.Services.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserDto> GetAll();
        public UserDto GetById(int id);

    }
}

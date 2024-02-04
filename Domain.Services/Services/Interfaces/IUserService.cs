using Domain.Services.Dtos;

namespace Domain.Services.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserDto> GetUsers();
    }
}

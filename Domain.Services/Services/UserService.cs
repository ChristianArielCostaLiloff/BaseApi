using Domain.Services.Dtos;
using Domain.Services.Services.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services
{
    public class UserService : IUserService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Services
        public List<UserDto> GetUsers()
        {
            IEnumerable<UserEntity> userEntities = _unitOfWork.UserRepository.GetAll();

            List<UserDto> usersDtos = userEntities.Select(user => new UserDto
            {
                Id = user.Id,
                Description = user.Description
            }).ToList();

            return usersDtos;
        }
        #endregion
    }
}

using Common.BaseApi.Exceptions;
using Common.BaseApi.Resources;
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

        #region Methods
        public List<UserDto> GetAll()
        {
            IEnumerable<UserEntity> userEntities = _unitOfWork.UserRepository.GetAll();

            List<UserDto> usersDtos = userEntities.Select(user => new UserDto
            {
                Id = user.Id,
                Description = user.Description
            }).ToList();

            return usersDtos;
        }

        public UserDto GetById(int id)
        {
            UserEntity? userEntity = _unitOfWork.UserRepository.FirstOrDefault(user => user.Id == id);

            if (userEntity == null)
            {
                throw new BusinessException(CrudMessages.NotFound);
            }

            UserDto userDto = new UserDto
            {
                Id = userEntity.Id,
                Description = userEntity.Description
            };

            return userDto;
        }
        #endregion
    }
}

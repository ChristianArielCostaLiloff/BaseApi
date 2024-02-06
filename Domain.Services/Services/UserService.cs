using Common.BaseApi.Exceptions;
using Common.BaseApi.Resources;
using Domain.Services.Dtos.User;
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

        #region Public Methods
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
            UserEntity userEntity = GetUserEntity(id);

            UserDto userDto = new UserDto
            {
                Id = userEntity.Id,
                Description = userEntity.Description
            };

            return userDto;
        }

        public async Task<bool> Insert(AddUserDto user)
        {
            UserEntity newUser = new UserEntity
            {
                Description = user.Description,
                IdRole = user.IdRole,
            };
            _unitOfWork.UserRepository.Insert(newUser);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(UpdateUserDto user)
        {
            UserEntity userEntity = GetUserEntity(user.Id);

            userEntity.Description = user.Description;
            userEntity.IdRole = user.IdRole;

            _unitOfWork.UserRepository.Update(userEntity);

            return await _unitOfWork.Save() > 0;
        }

        #endregion
        #region Public Methods
        private UserEntity GetUserEntity(int id)
        {
            UserEntity? userEntity = _unitOfWork.UserRepository.FirstOrDefault(user => user.Id == id);

            if (userEntity == null)
                throw new BusinessException(CrudMessages.NotFound);

            return userEntity;
        }
        #endregion
    }
}

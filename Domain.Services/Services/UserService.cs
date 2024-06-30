using Common.Exceptions;
using Common.Messages;
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
            IEnumerable<User> userEntityList = _unitOfWork.UserRepository.GetAll();

            List<UserDto> userDtoList = userEntityList.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name
            }).ToList();

            return userDtoList;
        }

        public UserDto GetById(int id)
        {
            User userEntity = GetUserEntity(id);

            UserDto userDto = new UserDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name
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

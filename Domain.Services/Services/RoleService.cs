using Common.Exceptions;
using Common.Messages;
using Domain.Services.Dtos.Role;
using Domain.Services.Dtos.User;
using Domain.Services.Services.Interfaces;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services
{
    public class RoleService : IRoleService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        public List<RoleDto> GetAll()
        {
            IEnumerable<Role> roleEntityList = _unitOfWork.RoleRepository.GetAll();

            List<RoleDto> roleDtoList = roleEntityList.Select(role => new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            }).ToList();

            return roleDtoList;
        }

        public RoleDto GetById(int id)
        {
            Role roleEntity = GetRoleEntity(id);

            RoleDto roleDto = new RoleDto
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };

            return roleDto;
        }

        public async Task<bool> Insert(AddRoleDto dto)
        {
            Role roleEntity = new Role
            {
                Name = dto.Name,
                Description = dto.Description ?? string.Empty,
            };
            _unitOfWork.RoleRepository.Insert(roleEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(UpdateRoleDto user)
        {
            Role roleEntity = GetRoleEntity(user.Id);

            roleEntity.Name = user.Name;
            roleEntity.Description = user.Description ?? string.Empty;

            _unitOfWork.RoleRepository.Update(roleEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            Role roleEntity = GetRoleEntity(id);

            _unitOfWork.RoleRepository.Delete(roleEntity);

            return await _unitOfWork.Save() > 0;
        }
        #endregion

        #region Private Methods
        private Role GetRoleEntity(int id)
        {
            Role? roleEntity = _unitOfWork.RoleRepository.FirstOrDefault(role => role.Id == id);

            if (roleEntity == null)
                throw new BusinessException(CrudMessages.NotFound);

            return roleEntity;
        }
        #endregion
    }
}

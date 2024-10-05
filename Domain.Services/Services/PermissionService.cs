using Common.Exceptions;
using Common.Messages;
using Domain.Services.Dtos.Permission;
using Domain.Services.Services.Interfaces;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Infraestructure.Entity.Models.Security;

namespace Domain.Services.Services
{
    public class PermissionService : IPermissionService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        public List<PermissionDto> GetAll()
        {
            IEnumerable<Permission> permissionEntityList = _unitOfWork.PermissionRepository.GetAll();

            List<PermissionDto> permissionDtoList = permissionEntityList.Select(permission => new PermissionDto
            {
                Id = permission.Id,
                Name = permission.Name
            }).ToList();

            return permissionDtoList;
        }

        public PermissionDto GetById(int id)
        {
            Permission permissionEntity = GetPermissionEntity(id);

            PermissionDto permissionDto = new PermissionDto
            {
                Id = permissionEntity.Id,
                Name = permissionEntity.Name
            };

            return permissionDto;
        }

        public async Task<bool> Insert(AddPermissionDto dto)
        {
            Permission permissionEntity = new Permission
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _unitOfWork.PermissionRepository.Insert(permissionEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(UpdatePermissionDto user)
        {
            Permission permissionEntity = GetPermissionEntity(user.Id);

            permissionEntity.Name = user.Name;
            permissionEntity.Description = user.Description;

            _unitOfWork.PermissionRepository.Update(permissionEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            Permission permissionEntity = GetPermissionEntity(id);

            _unitOfWork.PermissionRepository.Delete(permissionEntity);

            return await _unitOfWork.Save() > 0;
        }
        #endregion

        #region Private Methods
        private Permission GetPermissionEntity(int id)
        {
            Permission? permissionEntity = _unitOfWork.PermissionRepository.FirstOrDefault(permission => permission.Id == id);

            if (permissionEntity == null)
                throw new BusinessException(CrudMessages.NotFound);

            return permissionEntity;
        }
        #endregion

    }
}

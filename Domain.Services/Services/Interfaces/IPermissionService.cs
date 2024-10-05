using Domain.Services.Dtos.Permission;

namespace Domain.Services.Services.Interfaces
{
    public interface IPermissionService
    {
        public List<PermissionDto> GetAll();
        public PermissionDto GetById(int id);
        public Task<bool> Insert(AddPermissionDto dto);
        public Task<bool> Update(UpdatePermissionDto user);
        public Task<bool> Delete(int id);
    }
}

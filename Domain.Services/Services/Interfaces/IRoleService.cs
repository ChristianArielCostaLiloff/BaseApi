using Domain.Services.Dtos.Role;

namespace Domain.Services.Services.Interfaces
{
    public interface IRoleService
    {
        public List<RoleDto> GetAll();
        public RoleDto GetById(int id);
        public Task<bool> Insert(AddRoleDto dto);
        public Task<bool> Update(UpdateRoleDto user);
        public Task<bool> Delete(int id);

    }
}

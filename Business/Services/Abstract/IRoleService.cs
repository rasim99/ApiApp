using Business.Dtos.Role;
using Business.Wrappers;

namespace Business.Services.Abstract
{
    public interface IRoleService
    {
        Task<Response<List<RoleDto>>> GetAllRoleAsync();
    }
}

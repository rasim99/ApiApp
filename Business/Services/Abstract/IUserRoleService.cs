
using Business.Dtos.UserRole;
using Business.Wrappers;

namespace Business.Services.Abstract
{
    public interface IUserRoleService
    {
        Task<Response> AddRoleToUserAsync(UserAddToRoleDto model);
        Task<Response> RemoveRoleFromUserAsync(UserRemoveRoleDto model);
    }
}

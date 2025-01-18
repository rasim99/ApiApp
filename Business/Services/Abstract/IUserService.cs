using Business.Dtos.User;
using Business.Wrappers;

namespace Business.Services.Abstract
{
    public interface IUserService
    {
        Task<Response<List<UserDto>>> GetALLUserAsync();

    }
}

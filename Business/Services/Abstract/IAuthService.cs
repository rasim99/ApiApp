using Business.Dtos.Auth;
using Business.Wrappers;

namespace Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<Response> RegisterAsync(AuthRegisterDto model);
        Task<Response<AuthLoginResponseDto>> LoginAsync(AuthLoginDto model);
    }
}

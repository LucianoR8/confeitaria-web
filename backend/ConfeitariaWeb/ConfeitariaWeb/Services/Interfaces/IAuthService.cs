using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Auth;

namespace ConfeitariaWeb.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
    }
}

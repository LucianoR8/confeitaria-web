using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Auth;

namespace ConfeitariaWeb.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string senha);
        bool VerifyPassword(string senha, string senhaHash);
    }
}

using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiracao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
namespace ConfeitariaWeb.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string SenhaHash { get; set; } = string.Empty;

        public string Role { get; set; } = "Admin";

        public bool Ativo { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }
    }
}

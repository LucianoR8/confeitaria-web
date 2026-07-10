using System.ComponentModel.DataAnnotations;

namespace ConfeitariaWeb.Models
{
    public class Configuracao
    {
        [Key]
        public int IdConfiguracao { get; set; }
        public string NomeLoja { get; set; } = string.Empty;
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? WhatsApp { get; set; }
        public string? Email { get; set; }
        public string? LogoUrl { get; set; }
        public string? IconeUrl { get; set; }
        public string? BannerUrl { get; set; }
        public TimeOnly AbreAs { get; set; }
        public TimeOnly FechaAs { get; set; }
        public short QuantidadeMaximaDestaques { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }

}
namespace ConfeitariaWeb.DTOs.Configuracao
{
    public class ConfiguracaoUpdateDto
    {
        public string NomeLoja { get; set; } = string.Empty;
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? WhatsApp { get; set; }
        public string? Email { get; set; }
        public IFormFile? Logo { get; set; }
        public IFormFile? Icone { get; set; }
        public IFormFile? Banner { get; set; }
        public TimeOnly AbreAs { get; set; }
        public TimeOnly FechaAs { get; set; }
        public short QuantidadeMaximaDestaques { get; set; }
    }
}
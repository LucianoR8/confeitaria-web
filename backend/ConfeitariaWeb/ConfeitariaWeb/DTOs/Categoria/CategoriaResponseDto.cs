namespace ConfeitariaWeb.DTOs
{
    public class CategoriaResponseDto
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; } = string.Empty;
        public int QuantidadeProdutos { get; set; }
    }
}
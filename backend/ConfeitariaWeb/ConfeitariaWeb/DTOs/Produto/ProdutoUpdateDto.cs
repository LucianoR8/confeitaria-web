namespace ConfeitariaWeb.DTOs.Categoria
{
    public class ProdutoUpdateDto
    {
        public string NomeProduto { get; set; } = string.Empty;
        public string DescricaoProduto { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public bool Destaque { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;
        public string PrazoEntrega { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }
    }
}
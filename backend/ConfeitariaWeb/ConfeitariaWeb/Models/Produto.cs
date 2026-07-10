using System.ComponentModel.DataAnnotations;

namespace ConfeitariaWeb.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string? DescricaoProduto { get; set; }
        public decimal Preco { get; set; }
        public bool Destaque { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Slug { get; set; }
        public string PrazoEntrega { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }
}
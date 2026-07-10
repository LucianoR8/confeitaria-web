using System.ComponentModel.DataAnnotations;

namespace ConfeitariaWeb.Models
{
public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }
    public string NomeCategoria { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
}
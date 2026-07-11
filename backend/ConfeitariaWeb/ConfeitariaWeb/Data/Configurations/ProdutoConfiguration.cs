using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfeitariaWeb.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                   .HasColumnName("id_produto");

            builder.Property(p => p.NomeProduto)
                   .HasColumnName("nome_produto");

            builder.Property(p => p.DescricaoProduto)
                   .HasColumnName("descricao_produto");

            builder.Property(p => p.ImagemUrl)
                   .HasColumnName("imagem_url");

            builder.Property(p => p.Destaque)
                   .HasColumnName("destaque");

            builder.Property(p => p.Ativo)
                   .HasColumnName("ativo");

            builder.Property(p => p.PrazoEntrega)
                   .HasColumnName("prazo_entrega");

            builder.Property(p => p.Slug)
                   .HasColumnName("slug");

            builder.Property(p => p.Preco)
                   .HasColumnName("preco");

            builder.Property(p => p.CriadoEm)
                   .HasColumnName("criado_em");

            builder.Property(p => p.AtualizadoEm)
                   .HasColumnName("atualizado_em");

            builder.Property(p => p.CategoriaId)
               .HasColumnName("categoria_id");

            builder.HasOne(p => p.Categoria)
                   .WithMany(c => c.Produtos)
                   .HasForeignKey(p => p.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfeitariaWeb.Data.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categorias");

        builder.HasKey(c => c.IdCategoria);

        builder.Property(c => c.IdCategoria)
               .HasColumnName("id_categoria");

        builder.Property(c => c.NomeCategoria)
               .HasColumnName("nome_categoria");

        builder.Property(c => c.CriadoEm)
               .HasColumnName("criado_em");

        builder.Property(c => c.AtualizadoEm)
               .HasColumnName("atualizado_em");
    }
}
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfeitariaWeb.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.IdUsuario)
                   .HasColumnName("id_usuario");

            builder.Property(u => u.Nome)
                   .HasColumnName("nome");

            builder.Property(u => u.Email)
                   .HasColumnName("email");

            builder.Property(u => u.SenhaHash)
                   .HasColumnName("senha_hash");

            builder.Property(u => u.Role)
                   .HasColumnName("role");

            builder.Property(u => u.Ativo)
                   .HasColumnName("ativo");

            builder.Property(c => c.CriadoEm)
                    .HasColumnName("criado_em")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();

            builder.Property(c => c.AtualizadoEm)
                   .HasColumnName("atualizado_em");
        }
    }
}

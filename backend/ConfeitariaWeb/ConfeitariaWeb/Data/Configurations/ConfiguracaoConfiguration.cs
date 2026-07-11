using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfeitariaWeb.Data.Configurations
{
    public class ConfiguracaoConfiguration : IEntityTypeConfiguration<Configuracao>
    {
        public void Configure(EntityTypeBuilder<Configuracao> builder)
        {
            builder.ToTable("configuracoes");

            builder.HasKey(config => config.IdConfiguracao);

            builder.Property(config => config.IdConfiguracao)
                   .HasColumnName("id_configuracao");

            builder.Property(config => config.NomeLoja)
                   .HasColumnName("nome_loja");

            builder.Property(config => config.Instagram)
                   .HasColumnName("instagram");

            builder.Property(config => config.Endereco)
                   .HasColumnName("endereco");

            builder.Property(config => config.WhatsApp)
                   .HasColumnName("whatsapp");

            builder.Property(config => config.Facebook)
                   .HasColumnName("facebook");

            builder.Property(config => config.Telefone)
                   .HasColumnName("telefone");

            builder.Property(config => config.AbreAs)
                   .HasColumnName("abre_as");

            builder.Property(config => config.FechaAs)
                   .HasColumnName("fecha_as");

            builder.Property(config => config.Email)
                   .HasColumnName("email");

            builder.Property(config => config.QuantidadeMaximaDestaques)
                   .HasColumnName("quantidade_maxima_destaques");

            builder.Property(config => config.BannerUrl)
                   .HasColumnName("banner_url");

            builder.Property(config => config.LogoUrl)
                   .HasColumnName("logo_url");

            builder.Property(config => config.IconeUrl)
                   .HasColumnName("icone_url");

            builder.Property(config => config.CriadoEm)
                   .HasColumnName("criado_em");

            builder.Property(config => config.AtualizadoEm)
                   .HasColumnName("atualizado_em");
        }
    }
}

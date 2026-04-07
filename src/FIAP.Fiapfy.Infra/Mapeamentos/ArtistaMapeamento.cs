using FIAP.Fiapfy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Fiapfy.Infra.Mapeamentos
{
    public class ArtistaMapeamento : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artistas");

            builder.HasKey(a => a.Id);

            // int com IDENTITY no SQL Server (padrão do EF para int PK)
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(200);

            // Enum salvo como string para legibilidade no banco
            builder.Property(a => a.GeneroMusical)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(a => a.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}

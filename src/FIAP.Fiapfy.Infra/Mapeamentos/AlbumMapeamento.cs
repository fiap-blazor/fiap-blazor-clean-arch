using FIAP.Fiapfy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Fiapfy.Infra.Mapeamentos
{
    public class AlbumMapeamento : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.CapaUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.DataLancamento)
                .IsRequired();

            // Relacionamento Album → Artista (N:1)
            // Um álbum pertence a um artista
            // Um artista pode ter vários álbuns (não navegamos por Artista → Albums aqui)
            builder.HasOne(a => a.Artista)
                .WithMany()
                .HasForeignKey(a => a.ArtistaId)
                .OnDelete(DeleteBehavior.Restrict); // impede exclusão de artista com álbuns
        }
    }
}

using FIAP.Fiapfy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Fiapfy.Infra.Mapeamentos;

public class MusicaMapeamento : IEntityTypeConfiguration<Musica>
{
    public void Configure(EntityTypeBuilder<Musica> builder)
    {
        builder.ToTable("Musicas");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.Nome)
            .IsRequired()
            .HasMaxLength(200);

        // EF Core não suporta TimeSpan nativamente no SQL Server
        // Salva como FLOAT (total de segundos) e converte na leitura
        builder.Property(m => m.Duracao)
            .IsRequired()
            .HasConversion(
                v => v.TotalSeconds,
                v => TimeSpan.FromSeconds(v));

        // Relacionamento Musica → Album (N:1)
        // Uma música pertence a um álbum
        // Um álbum pode ter várias músicas (não navegamos por Album → Musicas aqui)
        builder.HasOne(m => m.Album)
            .WithMany()
            .HasForeignKey(m => m.AlbumId)
            .OnDelete(DeleteBehavior.Restrict); // impede exclusão de álbum com músicas
    }
}

using FIAP.Fiapfy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Fiapfy.Infra.Mapeamentos;

public class PlaylistMusicaConfiguration : IEntityTypeConfiguration<PlaylistMusica>
{
    public void Configure(EntityTypeBuilder<PlaylistMusica> builder)
    {
        builder.ToTable("PlaylistMusicas");

        // Chave composta — sem Id próprio pois PlaylistMusica não herda de Entity
        builder.HasKey(pm => new { pm.PlaylistId, pm.MusicaId });

        builder.Property(pm => pm.PlaylistId).IsRequired();
        builder.Property(pm => pm.MusicaId).IsRequired();
        builder.Property(pm => pm.DataAdicao).IsRequired();

        // Relacionamento → Playlist já configurado em PlaylistConfiguration (lado "dono")
        // Aqui apenas configuramos o lado Musica

        // Relacionamento PlaylistMusica → Musica (N:1)
        // Não usamos Cascade aqui para não deletar músicas ao remover da playlist
        builder.HasOne(pm => pm.Musica)
            .WithMany()
            .HasForeignKey(pm => pm.MusicaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

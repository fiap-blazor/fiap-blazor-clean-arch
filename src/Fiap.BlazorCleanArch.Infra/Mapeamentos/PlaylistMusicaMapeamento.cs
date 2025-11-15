using Fiap.BlazorCleanArch.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.BlazorCleanArch.Infra.Mapeamentos;

public class PlaylistMusicaMapeamento : IEntityTypeConfiguration<PlaylistMusica>
{
    public void Configure(EntityTypeBuilder<PlaylistMusica> builder)
    {
        builder.HasKey(mp => mp.Id);

        builder.Property(mp => mp.MusicaId)
            .IsRequired();

        builder.Property(mp => mp.PlaylistId)
            .IsRequired();

        builder.Property(mp => mp.DataAdicao)
            .IsRequired();

        builder.HasOne(mp => mp.Musica)
            .WithMany()
            .HasForeignKey(mp => mp.MusicaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(mp => new { mp.PlaylistId, mp.MusicaId })
            .IsUnique();

        builder.ToTable("PlaylistMusica");
    }
}

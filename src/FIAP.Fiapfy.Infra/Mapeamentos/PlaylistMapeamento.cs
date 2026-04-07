using FIAP.Fiapfy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Fiapfy.Infra.Mapeamentos;

public class PlaylistMapeamento : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.ToTable("Playlists");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Descricao)
            .HasMaxLength(1000);

        builder.Property(p => p.UsuarioId)
            .IsRequired()
            .HasMaxLength(100);

        // Relacionamento Playlist → PlaylistMusicas (1:N)
        // Este lado é o "dono" do relacionamento
        builder.HasMany(p => p.PlaylistMusicas)
            .WithOne(pm => pm.Playlist)
            .HasForeignKey(pm => pm.PlaylistId)
            .OnDelete(DeleteBehavior.Cascade); // ao deletar playlist, remove as junções

        // Aponta para o backing field _playlistMusicas (HashSet privado)
        builder.Navigation(p => p.PlaylistMusicas)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.BlazorCleanArch.Infra.Mapeamentos;

public class PlaylistMapeamento : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nome)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Descricao)
            .HasMaxLength(255);

        builder.Property(p => p.UsuarioId)
            .IsRequired();

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.UsuarioId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.UsuarioId);

        builder.HasMany(p => p.PlaylistMusicas)
            .WithOne(pm => pm.Playlist)
            .HasForeignKey(pm => pm.PlaylistId);

        builder.Navigation(p => p.PlaylistMusicas)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.ToTable("Playlist");
    }
}

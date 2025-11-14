using Fiap.BlazorCleanArch.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.BlazorCleanArch.Infra.Mapeamentos;

public class MusicaMapeamento : IEntityTypeConfiguration<Musica>
{
    public void Configure(EntityTypeBuilder<Musica> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(m => m.Duracao)
            .IsRequired();

        builder.HasOne(p => p.Album)
            .WithMany()
            .IsRequired();

        builder.ToTable("Musica");
    }
}

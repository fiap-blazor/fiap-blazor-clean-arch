using FIAP.Fiapfy.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Fiapfy.WebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistMusica> PlaylistMusicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica automaticamente todas as IEntityTypeConfiguration do assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

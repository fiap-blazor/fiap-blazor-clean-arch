using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Dominio.Interfaces;
using Fiap.BlazorCleanArch.Infra.Contexts;
using Fiap.BlazorCleanArch.Infra.Repositorios.Base;

namespace Fiap.BlazorCleanArch.Infra.Repositorios;

public class PlaylistsRepositorio : RepositorioBase<Playlist>, IPlaylistsRepositorio
{
    public PlaylistsRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }
}
